#include <stdio.h>
#include <time.h>

int main()
{
    int addition = 0;
    time_t raw_time = NULL;

    struct tm *date;

    int diff = 0;

    //Returns time in GMT, EST is -5
    time(&raw_time);

    date = localtime(&raw_time);

    //Seconds -> 60
    //Minutes -> 60
    //Hours   -> 24
    diff = raw_time % (86400);// - 18000;

    raw_time -= diff;

    //localtime_s(&date, &raw_time);
    date = gmtime(&raw_time);

    printf("Calc date: %04i/%02i/%02i %02i:%02i:%02i\n", date->tm_year + 1900, date->tm_mon + 1, date->tm_mday, date->tm_hour, date->tm_min, date->tm_sec);

    printf("Enter the number of days to add: ");
    scanf("%i", &addition);

    raw_time += (86400 * addition);

    date = gmtime(&raw_time);
    printf("Calc date: %04i/%02i/%02i %02i:%02i:%02i\n", date->tm_year + 1900, date->tm_mon + 1, date->tm_mday, date->tm_hour, date->tm_min, date->tm_sec);

    system("pause");

    return 0;
}
