﻿Option Strict On
Option Infer On

Module Example
    Sub Main()
        ' <Snippet19>
        Dim from1980 = Tuple.Create(1203339, 1027974, 951270)
        Dim from1910 As New Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, _
            Tuple(Of Integer, Integer, Integer)) _
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980)
        Dim population As New Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer, _ 
            Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, Tuple(Of Integer, Integer, Integer))) _
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910)
        ' </Snippet19>

        Console.WriteLine("Population of {0}", population.Item1)
        Console.WriteLine()
        Console.WriteLine("{0,5}  {1,14}  {2,10}", "Year", "Population", "Change")

        Dim year As Integer = population.Item2
        ShowPopulation(year, population.Item3)
        year += 10
        ShowPopulationChange(year, population.Item4, population.Item3)
        year += 10
        ShowPopulationChange(year, population.Item5, population.Item4)
        year += 10
        ShowPopulationChange(year, population.Item6, population.Item5)
        year += 10
        ShowPopulationChange(year, population.Item7, population.Item6)
        year += 10
        ShowPopulationChange(year, population.Rest.Item1, population.Item7)
        year += 10
        ShowPopulationChange(year, population.Rest.Item2, population.Rest.Item1)
        year += 10
        ShowPopulationChange(year, population.Rest.Item3, population.Rest.Item2)
        year += 10
        ShowPopulationChange(year, population.Rest.Item4, population.Rest.Item3)
        year += 10
        ShowPopulationChange(year, population.Rest.Item5, population.Rest.Item4)
        year += 10
        ShowPopulationChange(year, population.Rest.Item6, population.Rest.Item5)
        year += 10
        ShowPopulationChange(year, population.Rest.Item7, population.Rest.Item6)
        year += 10
        ShowPopulationChange(year, population.Rest.Rest.Item1, population.Rest.Item7)
        year += 10
        ShowPopulationChange(year, population.Rest.Rest.Item2, population.Rest.Rest.Item1)
        year += 10
        ShowPopulationChange(year, population.Rest.Rest.Item3, population.Rest.Rest.Item2)
    End Sub

    Private Sub ShowPopulationChange(ByVal year As Integer, ByVal newPopulation As Integer, ByVal oldPopulation As Integer)
        Console.WriteLine("{0,5}  {1,14:N0}  {2,10:P2}", year, newPopulation,
                          (newPopulation - oldPopulation) / oldPopulation / 10)
    End Sub

    Private Sub ShowPopulation(ByVal year As Integer, ByVal newPopulation As Integer)
        Console.WriteLine("{0,5}  {1,14:N0}  {2,10:P2}", year, newPopulation, "n/a")
    End Sub
End Module
' The example displays the following output:
'
'    Population of Detroit
'    Year      Population      Change
'    1860          45,619         n/a
'    1870          79,577      7.44 %
'    1880         116,340      4.62 %
'    1890         205,876      7.70 %
'    1900         285,704      3.88 %
'    1910         465,766      6.30 %
'    1920         993,078     11.32 %
'    1930       1,568,622      5.80 %
'    1940       1,623,452      0.35 %
'    1950       1,849,568      1.39 %
'    1960       1,670,144     -0.97 %
'    1970       1,511,462     -0.95 %
'    1980       1,203,339     -2.04 %
'    1990       1,027,974     -1.46 %
'    2000         951,270     -0.75 %
