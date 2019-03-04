#include <MCUFRIEND_kbv.h>

#define BUFFPIXEL 20

void bmpDraw(MCUFRIEND_kbv tft, char *filename, int x, int y);
uint16_t read16(File f);
uint32_t read32(File f);