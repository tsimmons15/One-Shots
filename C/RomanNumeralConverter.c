
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <ctype.h>

typedef struct {
	int value;
	char numeral;
} ROMAN_WEIGHTS;

typedef struct {
	int equivalent;
	char roman[100];
	int length;
} ROMAN_NUMERAL;

#define ROMAN_DIGITS 7

void processDigit(ROMAN_NUMERAL* numeral, ROMAN_WEIGHTS weights[], int* decimal, int first, int last);

int main() {
	char cont = 0;
	int decimal = 0;
	int current_digit = 0;
	int power = 0;
	ROMAN_NUMERAL numeral = { 0, "", 0 };
	ROMAN_WEIGHTS weights[ROMAN_DIGITS] = {
            { 1000, 'M' },
            { 500, 'D' },
            { 100, 'C' },
            { 50, 'L' },
            { 10, 'X' },
            { 5, 'V' },
            { 1, 'I' }
	};

	do {

		printf("Enter the number to convert to Roman Numeral: ");
		scanf_s("%i", &decimal);
		while (getchar() != '\n');

		//Clear any previous roman numeral out of the variable.
		for (int i = 0; i < 100; i++) {
			numeral.roman[i] = '\0';
		}
		numeral.equivalent = 0;
		numeral.length = 0;

		power = weights[0].value;
		int i = 0;
		while (power > 0) {
			//Can I get the correct digit I'm looking for?
			if (power > decimal) {
				power /= 10;
				i++;
				continue;
			}
			//Is the current weight appropriate for the value I'm looking at?
			if (weights[i].value > decimal) {
				i++;
				continue;
			}

			//What is my current digit?
			current_digit = decimal / power;

			//If it's a 4,
			if (current_digit == 4) {
				processDigit(&numeral, weights, &decimal, i - 1, i);
			}
			else if (current_digit == 9) {
				processDigit(&numeral, weights, &decimal, i - 1, i + 1);
			}
			else {
				while (decimal >= weights[i].value) {
					decimal -= weights[i].value;
					numeral.equivalent += weights[i].value;
					numeral.roman[numeral.length] = weights[i].numeral;
					numeral.length++;

				}
			}
		}

		printf("The Roman Numeral %s is equivalent to %i\n", numeral.roman, numeral.equivalent);

		printf("Enter another number? [Y]es or [N]o? ");
		scanf_s("%c", &cont, 1);
		while (getchar() != '\n');
		cont = tolower(cont);
	} while (cont != 'n');



	system("pause");
	return 0;
}

void processDigit(ROMAN_NUMERAL* numeral, ROMAN_WEIGHTS weights[], int* decimal, int first, int last) {
	//Then take the current weight value and subtract the subsequent from it
	*decimal -= weights[first].value - weights[last].value;
	numeral->equivalent += weights[first].value - weights[last].value;
	//And put those symbols (in opposite order because
	numeral->roman[numeral->length] = weights[last].numeral;
	numeral->length++;
	numeral->roman[numeral->length] = weights[first].numeral;
	numeral->length++;
}
