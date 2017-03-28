#include <stdio.h>
#include <time.h>

#define MAX_COLS 10

void printScoreboard(int arr[][2], int rows, int cols, char winFlag, char lossFlag, char tieFlag, char* noGameData);
char getScoreFlag(int team1, int team2, char winFlag, char lossFlag, char tieFlag);
int generateEvenTable(int dataSets);
char* padRight(char* msg, int length, char padChar);


int main()
{
	int numScores = 39;
	int numTracks = 2;
	int arr[1000][2] = { 0 };
	int i = 0;

	srand(time(NULL));

	//Randomize scores
	for (i = 0; i < numScores; i++)
	{
		arr[i][0] = rand() % 100 + 1;
		int op = rand() % 100 + 1;

		if (op > 50)
			arr[i][1] = arr[i][0] + rand() % 15 + 1;
		else if (op < 95)
			arr[i][1] = arr[i][0] - rand() % 15 + 1;
		else
			arr[i][1] = arr[i][0];

		//Enforces the constraint that a score cannot be negative
		//No other constraint is enforced
		arr[i][1] = (arr[i][1] >= 0) ? arr[i][1] : 0;
	}

	printScoreboard(arr, numScores, numTracks, 'W', 'L', 'T', padRight("No Data", 8, ' '));

	system("pause");

	return 0;
}

void printScoreboard(int arr[][2], int scores, int teams, char winFlag, char lossFlag, char tieFlag, char* noGameData)
{
	//Controls which series of data in the array we're printing.
	//tableRows needs to be the same as the number of cases in the switch
	int tableRows = 6;
	int tableRow = 0; //Tracks which series of data we're currently printing

	//Index of the data in the first column
	int i = 0;
	//The current column we're printing for the current data series
	int currCol = 0;
	int printCols = 10; //Tracks the number of columns to be displayed in the table, defaulted to 10

	//The weekNum is the current index of the array, at the specified currCol
	int gameNum = 0;

	//The scores for home and away -- used to determine whether to print 'winFlag' or 'lossFlag'
	int home = 0;
	int away = 0;

	//Try to find optimal number of cols to print for the number of data sets
	printCols = generateEvenTable(scores);

	//For each set of game statistics, do this loop
	//Since there is an internal counter that will go from i -> i+printCols, increment by printCols to get to the next block of statistics
	for (i = 0; i < scores; i += printCols)
	{
		//For each row in the table, do this loop
		while (tableRow < tableRows)
		{
			//For each column in the table, do this loop
			while (currCol < printCols)
			{
				//Gather the statistics for this current game
				gameNum = i + currCol;

				//The home score for gameNum is:
				home = arr[gameNum][0];
				//The other score for gameNum is:
				away = arr[gameNum][1];

				//Based on which row we're currently printing to...
				switch (tableRow)
				{
				//We're currently printing the header
				case 0:
					printf("|Week %4d|", gameNum + 1);
					break;
				//We're currently printing a divider on rows 1,3,5
				case 1:
				case 3:
				case 5:
					printf("|---------|");
					break;
				//We're currently printing our score
				case 2:
					//Determine if there is data to display for this column
					if (gameNum < scores)
						//(home > away) ? 'W' : 'L' will return 'W' if we win, or 'L' otherwise, L/L is a tie
						printf("|%2c %6i|", getScoreFlag(home, away, winFlag, lossFlag, tieFlag), home);
					else
						printf("|%9s|", noGameData);
					break;
				//We're currently printing their scores
				case 4:
					if (gameNum < scores)
						//(home < away) ? 'W' : 'L' will return 'W' if they win, or 'L' otherwise, L/L is a tie
						printf("|%2c %6i|", getScoreFlag(away, home, winFlag, lossFlag, tieFlag), away);
					else
						printf("|%9s|", noGameData);
					break;
				}

				//Move to the next column in our data series
				currCol++;
			}

			//We've finished one row in our table, move to the next row
			tableRow++;
			//Move down a line
			printf("\n");
			//Reset the column counter to 0
			currCol = 0;
		}

		//We've finished printing a set of 10 games, reset the row counter to 0
		tableRow = 0;
		//Move down another line, setting up a double line break
		printf("\n");
	}
}


//Returns a flag indicating whether the team won, lost, tied, or no game played
//Used in the printScoreboard function
//team1 is the team in question, if we're printing home score than team1 should be home
//team2 is the team that is not team1
//winFlag, lossFlag, and tieFlag are the flags passed to the printScoreboard function
char getScoreFlag(int team1, int team2, char winFlag, char lossFlag, char tieFlag)
{
	//Assume no game played
	char ret = ' ';

	//If team1 has beaten team2
	if (team1 > team2)
	{
		//set to win
		ret = winFlag;
	}
	//Otherwise, if team2 has beaten team1
	else if (team2 > team1)
	{
		//set to a loss
		ret = lossFlag;
	}
	else if (team1 >= 0)
	{
		ret = tieFlag;
	}

	return ret;
}

int generateEvenTable(int dataSets)
{
	int ret = MAX_COLS;
	int i = 0;

	if (dataSets <= 10)
		return dataSets;

	for (i = MAX_COLS; i > 5; i--)
	{
		if (dataSets % i == 0)
		{
			ret = i;
			break;
		}
	}

	return ret;
}


char* padRight(char* msg, int length, char padChar)
{
	char* newMsg = NULL;
	int i = 0;

	if (msg == NULL)
		msg = "No Data";

	newMsg = calloc(sizeof(char), length + 1);

	for (; i < length; i++)
	{
		if (msg[i] != '\0')
			newMsg[i] = msg[i];
		else
			newMsg[i] = padChar;
	}

	return newMsg;
}
