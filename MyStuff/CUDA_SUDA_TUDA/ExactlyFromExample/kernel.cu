
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <math.h>
#include <iostream>
#include <chrono>


__global__ void add_OneBlockOneThread(int n, float *x, float *y)
{
	for (int i = 0; i < n; i++)
		y[i] = x[i] + y[i];
}


__global__ void add_OneBlockManyThreads(int n, float *x, float *y)
{
	int index = threadIdx.x;
	int stride = blockDim.x;
	for (int i = index; i < n; i += stride)
		y[i] = x[i] + y[i];
}

__global__ void add_ManyBlocksManyThreads(int n, float *x, float *y)
{
	int index = blockIdx.x * blockDim.x + threadIdx.x;
	int stride = blockDim.x * gridDim.x;
	for (int i = index; i < n; i += stride)
		y[i] = x[i] + y[i];
}

int main(void)
{

	int N = 1 << 20; // 1048576 elements
	float *x, *y;
	std::chrono::steady_clock::time_point start, end;

	// Allocate Unified Memory – accessible from CPU or GPU
	cudaMallocManaged(&x, N * sizeof(float));
	cudaMallocManaged(&y, N * sizeof(float));

	int numberOfThreads;
	std::cout << "Input number of threads: ";
	std::cin >> numberOfThreads;
	std::cout << std::endl;

	// ========== One block, one thread ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}
	start = std::chrono::steady_clock::now();

	add_OneBlockOneThread <<< 1, 1 >>> (N, x, y);

	// Wait for GPU to finish before accessing on host
	cudaDeviceSynchronize();
	end = std::chrono::steady_clock::now();
	std::cout << "Elapsed time: " << std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count() << "ms" << std::endl;


	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}
	// ========== One block, many threads ========== //
	start = std::chrono::steady_clock::now();

	add_OneBlockManyThreads <<< 1, numberOfThreads >>> (N, x, y);

	cudaDeviceSynchronize();
	end = std::chrono::steady_clock::now();
	std::cout << "Elapsed time: " << std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count() << "ms" << std::endl;

	
	// ========== Many Blocks, many threads ========== //
	for (int i = 0; i < N; i++) {
		x[i] = 1.0f;
		y[i] = 2.0f;
	}
	
	start = std::chrono::steady_clock::now();

	int blockSize = numberOfThreads;
	int numBlocks = (N + blockSize - 1) / blockSize;
	add_ManyBlocksManyThreads <<< numBlocks, blockSize >>> (N, x, y);

	cudaDeviceSynchronize();
	end = std::chrono::steady_clock::now();
	std::cout << "Elapsed time: " << std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count() << "ms" << std::endl;


	// Free memory
	cudaFree(x);
	cudaFree(y);
	
	return 0;
}
