
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <omp.h>

#define WIDTH 10000
#define HEIGHT 10000
#define REPEATS 10

void fillImage(unsigned char image[HEIGHT][WIDTH]) {
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
            image[i][j] = rand() % 256;
        }
    }
}

void copyImage(
    unsigned char source[HEIGHT][WIDTH],
    unsigned char destination[HEIGHT][WIDTH]
) {
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {
            destination[i][j] = source[i][j];
        }
    }
}

void adjustBrightnessSerial(
    unsigned char image[HEIGHT][WIDTH],
    int brightness
) {
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {

            int value = image[i][j] + brightness;

            if (value > 255)
                value = 255;

            if (value < 0)
                value = 0;

            image[i][j] = (unsigned char)value;
        }
    }
}

void adjustBrightnessParallel(
    unsigned char image[HEIGHT][WIDTH],
    int brightness
) {
    #pragma omp parallel for
    for (int i = 0; i < HEIGHT; i++) {
        for (int j = 0; j < WIDTH; j++) {

            int value = image[i][j] + brightness;

            if (value > 255)
                value = 255;

            if (value < 0)
                value = 0;

            image[i][j] = (unsigned char)value;
        }
    }
}

int main() {

    static unsigned char original[HEIGHT][WIDTH];
    static unsigned char serial[HEIGHT][WIDTH];
    static unsigned char parallel[HEIGHT][WIDTH];

    int brightness;

    printf("Add meg a fenyero valtozast (pl. 42 vagy -42): ");
    if (scanf("%d", &brightness) != 1) {
        printf("Hibas bemenet.\n");
        return 1;
    }

    int threads;

    printf("Processzorok szama: %d\n", omp_get_num_procs());
    printf("Alapertelmezett szalak szama: %d\n", omp_get_max_threads());

    printf("Add meg a szalak szamat (1-%d): ", omp_get_max_threads());
    if (scanf("%d", &threads) != 1 || threads < 1 || threads > omp_get_max_threads()) {
        printf("Hibas bemenet.\n");
        return 1;
    }
    omp_set_num_threads(threads);

    srand(42);

    fillImage(original);

    copyImage(original, serial);
    copyImage(original, parallel);

    // Soros feldolgozás
    adjustBrightnessSerial(serial, brightness);

    double total = 0;
    for (int r = 0; r < REPEATS; r++) {
        copyImage(original, serial);
        double t = omp_get_wtime();
        adjustBrightnessSerial(serial, brightness);
        total += omp_get_wtime() - t;
    }
    double serialTime = total / REPEATS;

    // Párhuzamos feldolgozás
    adjustBrightnessParallel(parallel, brightness);

    total = 0;
    for (int r = 0; r < REPEATS; r++) {
        copyImage(original, parallel);
        double t = omp_get_wtime();
        adjustBrightnessParallel(parallel, brightness);
        total += omp_get_wtime() - t;
    }
    double parallelTime = total / REPEATS;

    // Eredmények ellenőrzése
    int identical = (memcmp(serial, parallel, sizeof serial) == 0);

    printf("Kep merete: %d x %d\n", WIDTH, HEIGHT);
    printf("Fenyero modositasa: %+d\n\n", brightness);

    printf("Soros feldolgozas: %.6f masodperc\n", serialTime);
    printf("Parhuzamos feldolgozas: %.6f masodperc\n", parallelTime);
    printf("Szalak szama: %d\n", omp_get_max_threads());
    printf("Gyorsitas: %.2fx\n", serialTime / parallelTime);

    printf("Az eredmenyek: %s\n",
        identical ? "azonosak" : "elternek"
    );
    return 0;
}