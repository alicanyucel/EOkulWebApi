namespace eOkulServer.Application.Features.Books.CreateBook;

public class ISBNValidator
{
    public static bool IsValidISBN10(string isbn)
    {
        if (isbn.Length != 10)
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            if (!char.IsDigit(isbn[i]))
                return false;
            sum += (10 - i) * (isbn[i] - '0');
        }

        char checkDigit = isbn[9];
        if (checkDigit == 'X')
        {
            sum += 10;
        }
        else if (char.IsDigit(checkDigit))
        {
            sum += (checkDigit - '0');
        }
        else
        {
            return false;
        }

        return (sum % 11 == 0);
    }

    public static bool IsValidISBN13(string isbn)
    {
        if (isbn.Length != 13)
            return false;

        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            if (!char.IsDigit(isbn[i]))
                return false;

            int digit = isbn[i] - '0';
            if (i % 2 == 0)
            {
                sum += digit;
            }
            else
            {
                sum += 3 * digit;
            }
        }

        int checkDigit = isbn[12] - '0';
        int calculatedCheckDigit = 10 - (sum % 10);
        if (calculatedCheckDigit == 10)
            calculatedCheckDigit = 0;

        return checkDigit == calculatedCheckDigit;
    }
}