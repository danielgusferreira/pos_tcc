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
('Feminino', 'Produtos masculinos' ),
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
('New Balance', 'Produtos New Balance');


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
VALUES('Adidas Superstar', 
	   'Tênis classico Adidas Superstar', 
	   GETDATE(), 
	   5, 2 , 
	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/7ed0855435194229a525aad6009a0497_9366/Tenis_Superstar_Branco_EG4958_01_standard.jpg', 
	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/8a358bcd5e3d453da815aad6009a249e_9366/Tenis_Superstar_Branco_EG4958_02_standard_hover.jpg', 
	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/ff2e419f1eda4ebab23faad6009a3a9e_9366/Tenis_Superstar_Branco_EG4958_04_standard.jpg',
	   'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/31cf91f6e16c4f0aa11caad6009a4590_9366/Tenis_Superstar_Branco_EG4958_05_standard.jpg'
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

INSERT INTO produto_dados([codigo_produto],[tamanho],[valor],[data_criacao],[estoque])
VALUES	(1, 39, 499.90, GETDATE(), 100),
		(1, 40, 499.90, GETDATE(), 100),
		(1, 41, 450.00, GETDATE(), 26),
		(1, 42, 399.90, GETDATE(), 12);


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



						    