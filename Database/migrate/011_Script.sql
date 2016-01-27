BEGIN_SETUP:

Update tbFeature set Href = '~/Currency' where id = 12

Alter table tbCurrency
	drop column CreateBy
	
	
Alter table tbCurrency
	drop column UpdateBy
	
GO

Alter table tbCurrency
	Add CreateBy uniqueidentifier not null
	
Alter table tbCurrency
	Add UpdateBy uniqueidentifier

END_SETUP: