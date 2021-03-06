USE [disciplina]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[apellidoPaterno] [varchar](50) NULL,
	[apellidoMaterno] [varchar](50) NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[privilegio] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[oficiales]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oficiales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[grado] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[apellidoPaterno] [varchar](100) NULL,
	[apellidoMaterno] [varchar](100) NULL,
	[codigo] [varchar](20) NULL,
	[direccion] [varchar](200) NULL,
	[telefono] [varchar](10) NULL,
	[carrera] [int] NULL,
	[ci] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faltasRac]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[faltasRac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NULL,
	[grado] [varchar](50) NULL,
	[puntos] [int] NULL,
 CONSTRAINT [PK_faltasRac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faltasEstudiantes]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[faltasEstudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEstudiante] [int] NULL,
	[IDCurso] [int] NULL,
	[IDFalta] [int] NULL,
	[fecha] [date] NULL,
	[concepto] [varchar](10) NULL,
	[detalleConcepto] [varchar](100) NULL,
	[puntos] [int] NULL,
 CONSTRAINT [PK_faltasEstudiantes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[estudiantes]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellidoPaterno] [varchar](100) NULL,
	[apellidoMaterno] [varchar](100) NULL,
	[codigo] [varchar](20) NULL,
	[direccion] [varchar](200) NULL,
	[telefono] [varchar](10) NULL,
	[carrera] [int] NULL,
	[ci] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[cursos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCarrera] [int] NOT NULL,
	[year] [int] NOT NULL,
	[periodo] [varchar](5) NOT NULL,
	[paralelo] [varchar](5) NULL,
	[curso] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cursoEstudiantes]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursoEstudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCurso] [int] NULL,
	[IDEstudiante] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carreras]    Script Date: 11/15/2015 18:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carreras](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
