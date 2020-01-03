# NokeLib for C#

## WeekDate
Specify year and week, get the first day and last day of the week.

* get the first day and last day of one week
```c#
public WeekDate(int year, int week)
public DateTime FirstDay
public DateTime LastDay
```
* get the first day and last day of range between two week
```c#
public static WeekDate GetRangeDate(int yearStart, int weekStart, int yearEnd, int weekEnd)
```
