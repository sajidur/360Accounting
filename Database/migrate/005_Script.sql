BEGIN_SETUP:

--Company Data
INSERT [dbo].[tbCompany] ([Name]) VALUES (N'Company 1')

--Set of Book Data
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (1, N'Book 1 of Company 1')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (1, N'Book 2 of Company 1')

END_SETUP: