
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <math.h>
#include <iostream>
#include <chrono>


__global__ void add_OneBlockOneThread(int n, float *x, float *y, float *z)
{
	for (int i = 0; i < n; i++)
		z[i] = x[i] + y[i];
}


__global__ void add_OneBlockManyThreads(int n, float *x, float *y, float *z)
{
	int index = threadIdx.x;
	int stride = blockDim.x;
	for (int i = index; i < n; i += stride)
		z[i] = x[i] + y[i];
}

__global__ void add_ManyBlocksManyThreads(int n, float *x, float *y, float *z)
{
	int index = blockIdx.x * blockDim.x + threadIdx.x;
	int stride = blockDim.x * gridDim.x;
	for (int i = index; i < n; i += stride)
		z[i] = x[i] + y[i];
}

__host__ void add_SingleThreadCPU(int n, float *x, float *y, float *z)
{
	for (int i = 0; i < n; ++i)
		z[i] = x[i] + y[i];
}

int main(void)
{

	int N = 1 << 20; // 1048576 elements
	float *x, *y, *z;

	// Allocate Unified Memory – accessible from CPU or GPU
	cudaMallocManaged(&x, N * sizeof(float));
	cudaMallocManaged(&y, N * sizeof(float));
	cudaMallocManaged(&z, N * sizeof(float));

	// ========== CPU, one thread ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}
	add_SingleThreadCPU(N, x, y, z);
	cudaDeviceSynchronize();

	// ========== One block, one thread ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}

	add_OneBlockOneThread <<< 1, 1 >>> (N, x, y, z);

	// Wait for GPU to finish before accessing on host
	cudaDeviceSynchronize();


	// ========== One block, many threads ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}

	add_OneBlockManyThreads <<< 1, 512 >>> (N, x, y, z);
	cudaDeviceSynchronize();

	// ========== Many Blocks, many threads ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}

	int blockSize = 512;
	int numBlocks = (N + blockSize - 1) / blockSize;

	add_ManyBlocksManyThreads <<< numBlocks, blockSize >>> (N, x, y, z);
	cudaDeviceSynchronize();



	cudaFree(x);
	cudaFree(y);
	cudaFree(z);

	return 0;
}
