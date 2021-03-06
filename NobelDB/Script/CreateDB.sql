CREATE DATABASE [Nobel]
GO

use Nobel
Go

/****** Object:  Table [dbo].[Categoria]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cidade]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cidade](
	[CidadeId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[PaisId] [int] NOT NULL,
	[CidadeAtualId] [int] NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[CidadeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Filiacao]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filiacao](
	[FiliacaoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[CidadeId] [int] NOT NULL,
 CONSTRAINT [PK_Filiacao] PRIMARY KEY CLUSTERED 
(
	[FiliacaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Laureado]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laureado](
	[LaureadoId] [int] NOT NULL,
	[LaureadoTipo] [char](1) NOT NULL,
 CONSTRAINT [PK_Laureado] PRIMARY KEY CLUSTERED 
(
	[LaureadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LaureadoIndividuo]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaureadoIndividuo](
	[LaureadoId] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[DataMorte] [date] NULL,
	[CidadeNascimentoId] [int] NOT NULL,
	[CidadeMorteId] [int] NULL,
	[Sexo] [char](1) NOT NULL,
 CONSTRAINT [PK_Individuo] PRIMARY KEY CLUSTERED 
(
	[LaureadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LaureadoIndividuoFiliacao]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaureadoIndividuoFiliacao](
	[LaureadoId] [int] NOT NULL,
	[FiliacaoId] [int] NOT NULL,
 CONSTRAINT [PK_LaureadoIndividuoFiliacao] PRIMARY KEY CLUSTERED 
(
	[LaureadoId] ASC,
	[FiliacaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LaureadoOrganizacao]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaureadoOrganizacao](
	[LaureadoId] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LaureadoOrganizacao_1] PRIMARY KEY CLUSTERED 
(
	[LaureadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LaureadoPremioNobel]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaureadoPremioNobel](
	[LaureadoId] [int] NOT NULL,
	[PremioNobelId] [int] NOT NULL,
 CONSTRAINT [PK_LaureadoPremioNobel] PRIMARY KEY CLUSTERED 
(
	[LaureadoId] ASC,
	[PremioNobelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pais]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[PaisId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[PaisAtualId] [int] NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PremioNobel]    Script Date: 27/10/2017 23:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PremioNobel](
	[PremioNobelId] [int] IDENTITY(1,1) NOT NULL,
	[Ano] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[Motivacao] [varchar](max) NULL,
 CONSTRAINT [PK_PremioNobel] PRIMARY KEY CLUSTERED 
(
	[PremioNobelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Cidade] FOREIGN KEY([CidadeAtualId])
REFERENCES [dbo].[Cidade] ([CidadeId])
GO
ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_Cidade]
GO
ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Pais] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisId])
GO
ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_Pais]
GO
ALTER TABLE [dbo].[Filiacao]  WITH CHECK ADD  CONSTRAINT [FK_Filiacao_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cidade] ([CidadeId])
GO
ALTER TABLE [dbo].[Filiacao] CHECK CONSTRAINT [FK_Filiacao_Cidade]
GO
ALTER TABLE [dbo].[LaureadoIndividuo]  WITH CHECK ADD  CONSTRAINT [FK_Individuo_Cidade] FOREIGN KEY([CidadeNascimentoId])
REFERENCES [dbo].[Cidade] ([CidadeId])
GO
ALTER TABLE [dbo].[LaureadoIndividuo] CHECK CONSTRAINT [FK_Individuo_Cidade]
GO
ALTER TABLE [dbo].[LaureadoIndividuo]  WITH CHECK ADD  CONSTRAINT [FK_Individuo_Cidade1] FOREIGN KEY([CidadeMorteId])
REFERENCES [dbo].[Cidade] ([CidadeId])
GO
ALTER TABLE [dbo].[LaureadoIndividuo] CHECK CONSTRAINT [FK_Individuo_Cidade1]
GO
ALTER TABLE [dbo].[LaureadoIndividuo]  WITH CHECK ADD  CONSTRAINT [FK_Individuo_Laureado] FOREIGN KEY([LaureadoId])
REFERENCES [dbo].[Laureado] ([LaureadoId])
GO
ALTER TABLE [dbo].[LaureadoIndividuo] CHECK CONSTRAINT [FK_Individuo_Laureado]
GO
ALTER TABLE [dbo].[LaureadoIndividuoFiliacao]  WITH CHECK ADD  CONSTRAINT [FK_LaureadoIndividuoFiliacao_Filiacao] FOREIGN KEY([FiliacaoId])
REFERENCES [dbo].[Filiacao] ([FiliacaoId])
GO
ALTER TABLE [dbo].[LaureadoIndividuoFiliacao] CHECK CONSTRAINT [FK_LaureadoIndividuoFiliacao_Filiacao]
GO
ALTER TABLE [dbo].[LaureadoIndividuoFiliacao]  WITH CHECK ADD  CONSTRAINT [FK_LaureadoIndividuoFiliacao_LaureadoIndividuo] FOREIGN KEY([LaureadoId])
REFERENCES [dbo].[LaureadoIndividuo] ([LaureadoId])
GO
ALTER TABLE [dbo].[LaureadoIndividuoFiliacao] CHECK CONSTRAINT [FK_LaureadoIndividuoFiliacao_LaureadoIndividuo]
GO
ALTER TABLE [dbo].[LaureadoOrganizacao]  WITH CHECK ADD  CONSTRAINT [FK_LaureadoOrganizacao_Laureado] FOREIGN KEY([LaureadoId])
REFERENCES [dbo].[Laureado] ([LaureadoId])
GO
ALTER TABLE [dbo].[LaureadoOrganizacao] CHECK CONSTRAINT [FK_LaureadoOrganizacao_Laureado]
GO
ALTER TABLE [dbo].[LaureadoPremioNobel]  WITH CHECK ADD  CONSTRAINT [FK_LaureadoPremioNobel_Laureado] FOREIGN KEY([LaureadoId])
REFERENCES [dbo].[Laureado] ([LaureadoId])
GO
ALTER TABLE [dbo].[LaureadoPremioNobel] CHECK CONSTRAINT [FK_LaureadoPremioNobel_Laureado]
GO
ALTER TABLE [dbo].[LaureadoPremioNobel]  WITH CHECK ADD  CONSTRAINT [FK_LaureadoPremioNobel_PremioNobel] FOREIGN KEY([PremioNobelId])
REFERENCES [dbo].[PremioNobel] ([PremioNobelId])
GO
ALTER TABLE [dbo].[LaureadoPremioNobel] CHECK CONSTRAINT [FK_LaureadoPremioNobel_PremioNobel]
GO
ALTER TABLE [dbo].[Pais]  WITH CHECK ADD  CONSTRAINT [FK_Pais_Pais] FOREIGN KEY([PaisAtualId])
REFERENCES [dbo].[Pais] ([PaisId])
GO
ALTER TABLE [dbo].[Pais] CHECK CONSTRAINT [FK_Pais_Pais]
GO
ALTER TABLE [dbo].[PremioNobel]  WITH CHECK ADD  CONSTRAINT [FK_PremioNobel_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[PremioNobel] CHECK CONSTRAINT [FK_PremioNobel_Categoria]
GO
ALTER TABLE [dbo].[Laureado]  WITH CHECK ADD  CONSTRAINT [CK_Laureado] CHECK  (([LaureadoTipo]='O' OR [LaureadoTipo]='I'))
GO
ALTER TABLE [dbo].[Laureado] CHECK CONSTRAINT [CK_Laureado]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Laureado é Individuo ou Organização' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Laureado', @level2type=N'CONSTRAINT',@level2name=N'CK_Laureado'
GO

/****** Object:  StoredProcedure [dbo].[LaureadosPorPaisAtual]    Script Date: 28/10/2017 01:25:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cláudio Teixeira
-- Create date: 28/10/2017
-- Description:	Devolve a contagem de Pessoas Laureados Nobel, agrupados por pais atual (de nascimento)
--				Devolve a contagem de laureados e não a contagem de prémios atribuídos
-- =============================================
CREATE PROCEDURE [dbo].[LaureadosPorPaisAtual]
	-- Add the parameters for the stored procedure here
	@paisId int = 0
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	
	select sum(x.partialSum) as [count], x.nome
	 from
	 (	
		select count(LaureadoIndividuo.LaureadoId) as partialSum, pais.Nome from LaureadoIndividuo
		inner join cidade on Cidade.CidadeId = LaureadoIndividuo.CidadeNascimentoId
		inner join pais on pais.PaisId = cidade.PaisId
		where pais.PaisAtualId is null and (@paisId = 0 or pais.PaisId = @paisId)
		group by pais.Nome
		union all
		select count(LaureadoIndividuo.LaureadoId) as partialSum, paisAtual.Nome from LaureadoIndividuo
		inner join cidade on Cidade.CidadeId = LaureadoIndividuo.CidadeNascimentoId
		inner join pais on pais.PaisId = cidade.PaisId
		inner join pais as paisAtual on pais.PaisAtualId = paisAtual.PaisId
		where  (@paisId = 0 or paisAtual.PaisId = @paisId)
		group by paisAtual.Nome
		) x
	group by x.Nome
	order by [count] desc

END

GO
/****** Object:  UserDefinedFunction [dbo].[PaisAtual]    Script Date: 28/10/2017 01:29:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cláudio Teixeira
-- Create date: 2017/10/28
-- Description:	Dado o id de um pais, devolve o paisId atual
-- =============================================
CREATE FUNCTION [dbo].[PaisAtual] 
(
	-- Add the parameters for the function here
	@PaisId int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	declare @paisAtualId int


	select @paisAtualId = pais.PaisAtualId from pais where PaisId = @PaisId

	if @paisAtualId is not null
		return @paisAtualId

	-- Return the result of the function
	RETURN @paisId

END

GO