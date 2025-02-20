using System;

namespace Chain1
{
    // <Snippet6>
    public class Chain1Example
    {
        public static void Main()
        {
            var pages = new Pages();
            if (!string.IsNullOrEmpty(pages.CurrentPage.Title))
            {
                string title = pages.CurrentPage.Title;
                Console.WriteLine($"Current title: '{title}'");
            }
        }
    }

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
                    if (_page[0] is null)
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

    // The example displays the following output:
    //    Unhandled Exception:
    //       System.NullReferenceException: Object reference not set to an instance of an object.
    //       at Chain1Example.Main()
    // </Snippet6>
}
