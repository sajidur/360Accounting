BEGIN_SETUP:

--Company Data
INSERT [dbo].[tbCompany] ([Name]) VALUES (N'Company 1')
INSERT [dbo].[tbCompany] ([Name]) VALUES (N'Company 2')
INSERT [dbo].[tbCompany] ([Name]) VALUES (N'Company 3')

--Set of Book Data
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (1, N'Book 1 of Company 1')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (1, N'Book 2 of Company 1')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (1, N'Book 3 of Company 1')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (2, N'Book 4 of Company 2')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (2, N'Book 5 of Company 2')
INSERT [dbo].[tbSetOfBook] ([CompanyId], [Name]) VALUES (3, N'Book 6 of Company 3')

END_SETUP: