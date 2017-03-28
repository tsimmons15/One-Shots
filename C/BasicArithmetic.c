#include <stdio.h>

int main()
{
	double numerator = 86.543, divisor = 4.32;
	int dividend = 0;
	double temp = numerator;

	double product = 0;
	double mult1 = 10.8, mult2 = 0.24;
	int i = 0;


	while ((numerator - divisor) > 0)
	{
		dividend++;
		numerator -= divisor;
	}

	printf("Test division:\n");
	printf("Homebrew   -> %lf / %lf = %lf\n", temp, divisor, dividend + (double)numerator / divisor);
	printf("'Official' -> %lf / %lf = %lf\n", temp, divisor, temp / divisor);

	temp = (mult1 <= mult2) ? mult1 : mult2;
	mult2 = (mult1 <= mult2) ? mult2 : mult1;
	mult1 = temp;

	for (i = 0; i < mult2; i++)
	{
		product += mult1;
	}

	printf("\n\nTest multiplication:\n");
	printf("Homebrew   -> %lf * %lf = %lf\n", mult1, mult2, product);
	printf("'Official' -> %lf * %lf = %lf\n", mult1, mult2, mult1 * mult2);

	system("pause");
}
