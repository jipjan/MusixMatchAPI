# MusixMatchAPI
A (full) Musixmatch API implementation for .NET

Most of the code is tested, except for the commercial parts of the API.

If you improved the code, don't hesitate to create a pull request!

The library is success/fail closure based.
Example usage:

```cs
var api = new MusixMatchApi("<your api key>");
var artistSearch = new ArtistSearch {ArtistName = "Daddy Yankee"};
api.ArtistSearch(artistSearch, result =>
{
    // Your results in result
}, error =>
{
    // Something went wrong. Error is in error string.
});
```
