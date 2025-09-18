#include <stdio.h>
#include <cuda_runtime.h>

int A[5] = {1, 2, 3, 4, 5}; // Host array (on CPU)

__device__ int dev_A[5]; // Device array (on GPU, in global memory)

__global__ void Multiply(int x){ // Kernel: multiplies each element of dev_A by x
    int i = threadIdx.x; // Each thread handles one index
    dev_A[i] = dev_A[i] * x; // Multiply element by x
}

int main(){
    cudaMemcpyToSymbol(dev_A, A, 5 * sizeof(int)); // Copy A (CPU) -> dev_A (GPU)
    Multiply<<<1, 5>>>(2); // Launch kernel with 1 block of 5 threads
    cudaMemcpyFromSymbol(A, dev_A, 5 * sizeof(int)); // Copy dev_A (GPU) -> A (CPU)

    // Print result
    for(int i = 0; i < 5; i++){
        printf("%d ", A[i]);
    }
}