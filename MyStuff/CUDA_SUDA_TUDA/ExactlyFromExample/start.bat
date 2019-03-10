nvcc kernel.cu -o add_cuda
nvprof ./add_cuda
PAUSE