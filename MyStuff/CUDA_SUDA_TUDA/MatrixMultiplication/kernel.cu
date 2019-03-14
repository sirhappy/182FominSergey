
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <math.h>
#include <iostream>

__global__ void transposeMatrix(const int *a, const int *b)
{
    int idx = blockIdx.x * blockDim.x + threadIdx.x;
}

int main()
{
	const int MATRIX_SIZE = 3;
	const int N = MATRIX_SIZE * MATRIX_SIZE;

	float *a, *b, *c;
	cudaMallocManaged(&a, N * sizeof(float));
	cudaMallocManaged(&b, N * sizeof(float));

	for (int i = 0; i < N; ++i)
	{
		a[i] = 1.0f;
		b[i] = 2.0f;
	}

	
    return 0;
}
