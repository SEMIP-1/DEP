--Part 03

--1. Create a stored procedure that calculates the sum of a given range of numbers
create procedure sp_sum_range
    @start int,
    @end int
as
begin
    declare @sum int = 0;
    declare @i int = @start;

    while @i <= @end
    begin
        set @sum += @i;
        set @i += 1;
    end

    print 'sum of numbers between ' + cast(@start as varchar) + ' and ' + cast(@end as varchar) + ' is: ' + cast(@sum as varchar);
end;
go
--2. Create a stored procedure that calculates the area of a circle given its radius
create procedure sp_circle_area
    @radius float
as
begin
    declare @area float;
    set @area = pi() * power(@radius, 2);

    print 'area of the circle with radius ' + cast(@radius as varchar) + ' is: ' + cast(@area as varchar);
end;
go
--3. Create a stored procedure that calculates the age category based on a person's age 
--( Note: IF Age < 18 then Category is Child and if  Age >= 18 AND Age < 60 then Category is Adult otherwise  Category is Senior)
create procedure sp_age_category
    @age int
as
begin
    declare @category varchar(20);

    if @age < 18
        set @category = 'child';
    else if @age >= 18 and @age < 60
        set @category = 'adult';
    else
        set @category = 'senior';

    print 'the person with age ' + cast(@age as varchar) + ' is categorized as: ' + @category;
end;
go
--4. Create a stored procedure that determines the maximum, minimum, and average of a given set of numbers ( Note : set of numbers as Numbers = '5, 10, 15, 20, 25')
--??