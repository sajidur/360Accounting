BEGIN_SETUP:
alter table [dbo].[tbFeature]
	add Href varchar(255),
	Class varchar(50)
GO
END_SETUP: