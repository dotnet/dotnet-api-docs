using System;
using System.Globalization;

public partial class Default2
{
    private sealed class TextBox
    {
        public string Text { get; set; } = string.Empty;
    }

    private sealed class Label
    {
        public string Text { get; set; } = string.Empty;
    }

    private sealed class RequestContext
    {
        public string[] UserLanguages { get; } = [CultureInfo.CurrentCulture.Name];
    }

    private readonly TextBox inputNumber = new();
    private readonly Label outputNumber = new();
    private RequestContext Request { get; } = new();

    // <Snippet1>
    protected void OkToSingle_Click(object sender, EventArgs e)
    {
        string locale;
        float number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = float.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet1>

    // <Snippet2>
    protected void OkToDouble_Click(object sender, EventArgs e)
    {
        string locale;
        double number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = double.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (OverflowException)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet2>

    // <Snippet3>
    protected void OkToDecimal_Click(object sender, EventArgs e)
    {
        string locale;
        decimal number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = decimal.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet3>

    // <Snippet4>
    protected void OkToInteger_Click(object sender, EventArgs e)
    {
        string locale;
        int number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = int.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet4>

    // <Snippet5>
    protected void OkToLong_Click(object sender, EventArgs e)
    {
        string locale;
        long number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = long.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet5>

    // <Snippet6>
    protected void OkToUInteger_Click(object sender, EventArgs e)
    {
        string locale;
        uint number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = uint.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet6>

    // <Snippet7>
    protected void OkToULong_Click(object sender, EventArgs e)
    {
        string locale;
        ulong number;
        CultureInfo culture;

        // Return if string is empty
        if (string.IsNullOrEmpty(this.inputNumber.Text))
            return;

        // Get locale of web request to determine possible format of number
        if (Request.UserLanguages.Length == 0)
            return;
        locale = Request.UserLanguages[0];
        if (string.IsNullOrEmpty(locale))
            return;

        // Instantiate CultureInfo object for the user's locale
        culture = new(locale);

        // Convert user input from a string to a number
        try
        {
            number = ulong.Parse(this.inputNumber.Text, culture.NumberFormat);
        }
        catch (FormatException)
        {
            return;
        }
        catch (Exception)
        {
            return;
        }
        // Output number to label on web form
        this.outputNumber.Text = "Number is " + number.ToString();
    }
    // </Snippet7>
}
