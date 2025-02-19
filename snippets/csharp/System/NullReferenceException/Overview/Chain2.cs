// <Snippet7>
using System;

public class Chain2Example
{
    public static void Main()
    {
        var pages = new Pages();
        Page current = pages.CurrentPage;
        if (current != null)
        {
            string title = current.Title;
            Console.WriteLine($"Current title: '{title}'");
        }
        else
        {
            Console.WriteLine("There is no page information in the cache.");
        }
    }
}
// The example displays the following output:
//       There is no page information in the cache.
// </Snippet7>

public class Pages
{
    readonly Page[] _page = new Page[10];
    int _ctr = 0;

    public Page CurrentPage
    {
        get { return _page[_ctr]; }
        set
        {
            // Move all the page objects down to accommodate the new one.
            if (_ctr > _page.GetUpperBound(0))
            {
                for (int ndx = 1; ndx <= _page.GetUpperBound(0); ndx++)
                    _page[ndx - 1] = _page[ndx];
            }
            _page[_ctr] = value;
            if (_ctr < _page.GetUpperBound(0))
                _ctr++;
        }
    }

    public Page PreviousPage
    {
        get
        {
            if (_ctr == 0)
            {
                if (_page[0] == null)
                    return null;
                else
                    return _page[0];
            }
            else
            {
                _ctr--;
                return _page[_ctr + 1];
            }
        }
    }
}

public class Page
{
    public Uri URL;
    public string Title;
}
