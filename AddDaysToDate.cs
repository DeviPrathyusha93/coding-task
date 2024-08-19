using System;

public class AddDate
{
    public static void Main()
    {
        //user to provide date
        Console.WriteLine($"Please enter a date in dd/mm/yyyy format:");
        string userDateInput = Console.ReadLine();

        //user to provide number of days to be added
        Console.WriteLine($"Please number of days to be added:");
        int numberofdaysToAdd = int.Parse(Console.ReadLine());

        var partDate = userDateInput.Split('/');
        
        int day = int.Parse(partDate[0]);
        int month = int.Parse(partDate[1]);
        int year = int.Parse(partDate[2]);

        var newDate = AddNewDays(day, month, year, numberofdaysToAdd);

        Console.WriteLine($"New Date after adding the number of days: {newDate[0]:00}/{newDate[1]:00}/{newDate[2]}");
    }
    
    //checking if the provided year is a leap year or not
    public static bool IsLeapYear(int year)
    {
        if(year % 4 == 0)
        {
            return true;
        }
        else 
           return false;
    }

    public static int[] AddNewDays(int day, int month, int year, int numberofdaysToAdd)
    {
        int[] numberofdaysInMonth = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        //Handling leap year
        if(IsLeapYear(year))
        {
            numberofdaysInMonth[1] = 29;
        }
        day += numberofdaysToAdd;
        
        //when the day or month is provided  to greater than which are already declared
        //It will check for number of days in a month which are delared above and will adjust to that
        while(day > numberofdaysInMonth[month - 1])
        {
            day -= numberofdaysInMonth[month - 1];
            month++;
            
            if(month > 12)
            {
                month = 1;
                year++;

                numberofdaysInMonth[1] = IsLeapYear(year) ? 29 : 28;
            }
        }

        return new int[] { day, month, year };
    }
}