1. the LINQ docs C# samples [in GitHub repo] consist of 6 projects to showcase IEnumerable and IQueryable
unfortunately much code unecessarily invokes AsQueryable despite simpler IEnumerable method implementations existing
- [thus such guidance is poor as such AsQueryable () can be avoided]
2. should update to useful modern C# v12 semantics [Primary constructors, Collection expressions, Span, is, etc]
3. calls made to default parameterless ctor then assigning individual properties, rather than using parameterised ctors explicitly
- or better yet primary constructor
4. current analyzers also disclose numerous Warnings/Messages, emphasising poor guidance for today's coding
5. many cases of wastefully using Any(),Count(),LongCount etc when optimal coding available (e.g. Count, Length for Collections).
6. spurious ToString() call in OrderByIComparer() [line #1804]
