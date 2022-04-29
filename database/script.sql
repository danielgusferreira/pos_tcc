CREATE TABLE usuario_perfil (
  [codigo] INT NOT NULL IDENTITY,
  [nome] VARCHAR(50) NOT NULL,
  PRIMARY KEY ([codigo])
);

INSERT INTO usuario_perfil([nome]) VALUES('adm'), ('funcionario'), ('padrão');


CREATE TABLE usuario (
  [codigo] INT NOT NULL IDENTITY,
  [codigo_perfil] INT NOT NULL,
  [nome] VARCHAR(50) NOT NULL,
  [email] VARCHAR(50) NOT NULL,
  [senha] VARCHAR(150) NOT NULL,
  [data_criacao] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_usuario_usuario_perfil]
  FOREIGN KEY ([codigo_perfil])
  REFERENCES usuario_perfil([codigo])
);

INSERT INTO usuario([codigo_perfil], [nome], [email], [senha], [data_criacao]) 
			VALUES(1, 'adm 1', 'adm1@gmail.com', '123456', getdate()), 
				  (2, 'func 1', 'func1@gmail.com', '123456', getdate()), 
				  (3, 'usuario 1', 'usuario1@gmail.com', '123456', getdate());


CREATE TABLE usuario_dados (
  [codigo] INT NOT NULL IDENTITY,
  [codigo_usuario] INT NOT NULL,
  [cpf] VARCHAR(11) NOT NULL,
  [data_nascimento] DATETIME2(0) NOT NULL,
  [telefone] VARCHAR(11) NOT NULL,
  [cep] VARCHAR(10) NOT NULL,
  [endereco] VARCHAR(100) NOT NULL,
  [numero] VARCHAR(50) NOT NULL,
  [complemento] VARCHAR(100) NULL,
  [bairro] VARCHAR(50) NOT NULL,
  [cidade] VARCHAR(50) NOT NULL,
  [uf] VARCHAR(3) NOT NULL,
  [data_criacao] DATETIME2(0) NOT NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_usuario_dados_usuario1]
  FOREIGN KEY ([codigo_usuario])
  REFERENCES usuario ([codigo])
);



INSERT INTO usuario_dados([codigo_usuario], [cpf],[data_nascimento],[telefone],[cep] ,[endereco] ,[numero],[complemento] ,[bairro],[cidade],[uf] ,[data_criacao]) 
	VALUES(1, '10333365476', '1990-08-03', '31987554323', '32260430', 'Rua XPTO', '10', '',     'Centro',    'BH', 'MG', getdate()), 
		  (2, '10333365477', '1995-09-04', '31987554323', '32260431', 'Rua XPTO', '12', '',     'Belvedere', 'BH', 'MG', getdate()), 
		  (3, '10333365478', '1999-10-05', '31987554323', '32260432', 'Rua XPTO', '13', 'Casa', 'Pampulha',  'BH', 'MG', getdate());




CREATE TABLE produto_categoria (
  [codigo] INT NOT NULL IDENTITY,
  [nome] VARCHAR(50) NOT NULL,
  [descricao] VARCHAR(250) NULL,
  PRIMARY KEY ([codigo])
);

INSERT INTO produto_categoria(nome, descricao) VALUES 
('Masculino', 'Produtos masculinos' ),
('Feminino', 'Produtos femininos' ),
('Chuteiras', 'Produtos Chuteiras' ),
('SkateBoard', 'Produtos skateBoard' ),
('Casual', 'Produtos casual');



CREATE TABLE marca_produto (
  [codigo] INT NOT NULL IDENTITY,
  [nome] VARCHAR(50) NOT NULL,
  [descricao] VARCHAR(250) NULL,
  PRIMARY KEY ([codigo])
);

INSERT INTO marca_produto(nome, descricao) VALUES 
('Nike', 'Produtos Nike' ),
('Adidas', 'Produtos Adidas' ),
('Rebook', 'Produtos Rebook' ),
('Vans', 'Produtos Vans' ),
('New Balance', 'Produtos New Balance'),
('Puma', 'Produtos Puma' );


CREATE TABLE produto (
  [codigo] INT NOT NULL IDENTITY,
  [nome] VARCHAR(50) NOT NULL,
  [descricao] VARCHAR(250) NOT NULL,
  [data_criacao] DATETIME2(0) NOT NULL,
  [codigo_categoria] INT NOT NULL,
  [codigo_marca] INT NOT NULL,
  [foto1] VARCHAR(250) NOT NULL,
  [foto2] VARCHAR(250) NULL,
  [foto3] VARCHAR(250) NULL,
  [foto4] VARCHAR(250) NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_produto_produto_categoria1]
  FOREIGN KEY ([codigo_categoria])
  REFERENCES produto_categoria ([codigo]),
  CONSTRAINT [fk_produto_marca_produto1]
  FOREIGN KEY ([codigo_marca])
  REFERENCES marca_produto ([codigo])
);

INSERT INTO produto([nome],[descricao],[data_criacao],[codigo_categoria],[codigo_marca],[foto1],[foto2],[foto3],[foto4])
VALUES
	--('Adidas Superstar', 
--	   'Tênis classico Adidas Superstar', 
--	   GETDATE(), 
--	   5, 2 , 
--	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/7ed0855435194229a525aad6009a0497_9366/Tenis_Superstar_Branco_EG4958_01_standard.jpg', 
--	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/8a358bcd5e3d453da815aad6009a249e_9366/Tenis_Superstar_Branco_EG4958_02_standard_hover.jpg', 
--	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/ff2e419f1eda4ebab23faad6009a3a9e_9366/Tenis_Superstar_Branco_EG4958_04_standard.jpg',
--	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/31cf91f6e16c4f0aa11caad6009a4590_9366/Tenis_Superstar_Branco_EG4958_05_standard.jpg'
--	  ),
	  
	  ('Adidas NMD R1', 
	   'Tênis Adidas NMD R1 Primeknit Camo Verde', 
	   GETDATE(), 
	   5, 2 , 
	   'https://cdn.shopify.com/s/files/1/0088/1587/0029/products/TENISADIDASNMDR1PRIMEKNITCAMOVERDE_1_600x_crop_center.jpg?v=1618940520', 
	   'https://cdn.shopify.com/s/files/1/0088/1587/0029/products/TENISADIDASNMDR1PRIMEKNITCAMOVERDE_5_600x_crop_center.jpg?v=1618940521', 
	   'https://cdn.shopify.com/s/files/1/0088/1587/0029/products/TENISADIDASNMDR1PRIMEKNITCAMOVERDE_3_600x_crop_center.jpg?v=1618940521',
	   'https://cdn.shopify.com/s/files/1/0088/1587/0029/products/TENISADIDASNMDR1PRIMEKNITCAMOVERDE_6_600x_crop_center.jpg?v=1618940521'
	  ),
	  	  ('Nike Court Vision Low', 
	   'Conheça o Nike Court Vision Low. Sua parte de cima texturizada e suas sobreposições costuradas são inspiradas no look de arremessos livres do basquete das antigas.', 
	   GETDATE(), 
	   5, 1 , 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-court-vision-lo-nba-DM1187-103-1-11638987605.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-court-vision-lo-nba-DM1187-103-2-21638987607.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-court-vision-lo-nba-DM1187-103-4-41638987611.jpg',
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-court-vision-lo-nba-DM1187-103-6-61638987615.jpg'
	  ),

	  	  ('Air Jordan 1 Mid', 
	   'O tênis Air Jordan 1 Mid é inspirado no primeiro modelo AJ1, oferecendo aos fãs dos Jordan retrôs a oportunidade de seguir os passos da grandeza.', 
	   GETDATE(), 
	   5, 1 , 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-096-1-11628865979.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-096-2-21628865980.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-096-8-81628865986.jpg',
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-096-11-111628865988.jpg'
	  ),

	  	  ('Nike Air Max Bella TR 5', 
	   'O Nike Air Max Bella TR 5 combina o impulso e a beleza do amortecimento Max Air com uma sola plana que proporciona uma vantagem estabilizadora enquanto você tonifica e se define na musculação. ', 
	   GETDATE(), 
	   2, 1, 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-w-nike-air-max-bella-tr-5-DD9285-656-1-11638990478.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-w-nike-air-max-bella-tr-5-DD9285-656-2-21638990480.jpg', 
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-w-nike-air-max-bella-tr-5-DD9285-656-3-31638990483.jpg',
	   'https://images.lojanike.com.br/1024x1024/produto/tenis-w-nike-air-max-bella-tr-5-DD9285-656-4-41638990485.jpg'
	  ),

	  	  ('CHUTEIRA ULTRA 3.3', 
	   'Velocidade é o nome do jogo com a chuteira PUMA ULTRA 3.3 Campo ', 
	   GETDATE(), 
	   3, 6, 
	   'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa/global/106667/01/sv01/fnd/BRA/w/1000/h/1000/fmt/png', 
	   'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa/global/106667/01/fnd/BRA/w/1000/h/1000/fmt/png', 
	   'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa/global/106667/01/bv/fnd/BRA/w/1000/h/1000/fmt/png',
	   'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa/global/106667/01/sv04/fnd/BRA/w/1000/h/1000/fmt/png'
	  );


CREATE TABLE produto_dados (
  [codigo] INT NOT NULL IDENTITY,
  [codigo_produto] INT NOT NULL,
  [tamanho] VARCHAR(10) NOT NULL,
  [valor] DECIMAL(10,0) NOT NULL,
  [data_criacao] DATETIME2(0) NOT NULL,
  [estoque] INT NOT NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_produto_sku_produto1]
  FOREIGN KEY ([codigo_produto])
  REFERENCES produto ([codigo])
);

INSERT INTO produto_dados([codigo_produto],[tamanho],[valor],[data_criacao],[estoque]) VALUES	
	--(1, 39, 499.90, GETDATE(), 100),
	--(1, 40, 499.90, GETDATE(), 100),
	--(1, 41, 450.00, GETDATE(), 26),
	--(1, 42, 399.90, GETDATE(), 12),
		
	(4, 39, 600.90, GETDATE(), 100),
	(4, 40, 699.90, GETDATE(), 100),
	(4, 41, 625.00, GETDATE(), 26),
	(4, 42, 670.90, GETDATE(), 12),
		
	(5, 39, 399.90, GETDATE(), 100),
	(5, 40, 399.90, GETDATE(), 100),
	(5, 41, 350.00, GETDATE(), 26),
	(5, 42, 299.90, GETDATE(), 12),

	(6, 39, 999.90, GETDATE(), 100),
	(6, 40, 1150.90, GETDATE(), 5),
	(6, 41, 999.00, GETDATE(), 7),
	(6, 42, 899.90, GETDATE(), 3),
		
	(7, 33, 799.90, GETDATE(), 66),
	(7, 34, 799.90, GETDATE(), 50),
	(7, 35, 799.00, GETDATE(), 26),
	(7, 36, 650.00, GETDATE(), 2),
		
	(8, 39, 599.90, GETDATE(), 100),
	(8, 40, 599.90, GETDATE(), 100),
	(8, 41, 500.00, GETDATE(), 26),
	(8, 42, 599.90, GETDATE(), 12);


CREATE TABLE meio_pagamento (
  [codigo] INT NOT NULL IDENTITY,
  [nome] VARCHAR(45) NOT NULL,
  [descricao] VARCHAR(200) NULL,
  PRIMARY KEY ([codigo]));

INSERT INTO meio_pagamento(nome, descricao)
VALUES	('Débito', 'Meio de Pagamento Débito'),
		('Boleto Bancario', 'Meio de Pagamento Débito'),
		('PIX', 'Meio de Pagamento Débito');


CREATE TABLE carrinho (
  [codigo] INT NOT NULL IDENTITY,
  [quantidade] INT NOT NULL,
  [codigo_produto_dados] INT NOT NULL,
  [usuario_codigo] INT NOT NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_produtos_carrinho_produto_sku1]
  FOREIGN KEY ([codigo_produto_dados])
  REFERENCES produto_dados ([codigo]),
  CONSTRAINT [fk_produtos_carrinho_usuario1]
  FOREIGN KEY ([usuario_codigo])
  REFERENCES usuario ([codigo])
);




CREATE TABLE pedido (
  [codigo] INT NOT NULL IDENTITY,
  [data_pedido] DATETIME2(0) NOT NULL,
  [data_envio] DATETIME2(0) NULL,
  [codigo_rastreio] VARCHAR(50) NULL,
  [status] INT NOT NULL,
  [codigo_meio_pagamento] INT NOT NULL,
  [codigo_carrinho] INT NOT NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_pedido_meio_pagamento1]
  FOREIGN KEY ([codigo_meio_pagamento])
  REFERENCES meio_pagamento ([codigo]),
  CONSTRAINT [fk_pedido_carrinho1]
  FOREIGN KEY ([codigo_carrinho])
  REFERENCES carrinho ([codigo])
);


CREATE TABLE comentario (
  [codigo] INT NOT NULL IDENTITY,
  [codigo_usuario] INT NOT NULL,
  [codigo_produto_dados] INT NOT NULL,
  [nota] INT NOT NULL,
  [descricao] VARCHAR(500) NULL,
  PRIMARY KEY ([codigo]),
  CONSTRAINT [fk_comentario_usuario1]
  FOREIGN KEY ([codigo_usuario])
  REFERENCES usuario ([codigo]),
  CONSTRAINT [fk_comentario_produto_sku1]
  FOREIGN KEY ([codigo_produto_dados])
  REFERENCES produto_dados ([codigo])
);

INSERT INTO comentario([codigo_usuario], [codigo_produto_dados], [nota], [descricao])
VALUES(3, 1, 5, 'Produto muito bom!');						    