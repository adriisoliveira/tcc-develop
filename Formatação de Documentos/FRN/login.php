<?php
	session_start();
	if(!isset($_SESSION['erro'])){
		$_SESSION['erro']=0;
	}
	require_once "conexao.php";
?>
<html lang="pt-br">
	<head>
		<title>Login</title>
		<meta charset="UTF-8"/>
	<link type="text/css" href="css/style.css" rel="stylesheet"/>
	<link rel="stylesheet" href="css/bootstrap.min.css"/>
	<link rel="stylesheet" href="css/font-awesome.min.css"/>
	<link rel="stylesheet" href="css/flaticon.css"/>
	<link rel="stylesheet" href="css/slicknav.min.css"/>
	<link rel="stylesheet" href="css/jquery-ui.min.css"/>
	<link rel="stylesheet" href="css/owl.carousel.min.css"/>
	<link rel="stylesheet" href="css/animate.css"/>
	<link rel="stylesheet" href="css/styless.css"/>
	</head>
	<body>
		
			<?php
					require_once "includes/head.php";
				?>
				
				<div class="page-top-info">
		<div class="container">
			<h4>Login</h4>
			<div class="site-pagination">
				<a href="index.php">Home</a>
			</div>
		</div>
	</div>
				<div class="cadast">
				<h5> Preencha para fazer o Login </h5><br>
					<form class="cad-form" name="form1" method="post" action="teste_login.php">
						<br/>
						<input placeholder="RM" name="RM" type="text" id="RM">
						<br/>
						<br/>
						<input placeholder="Senha" name="senha" type="password" id="senha">
						<br/>
						<br/>
						<input type="submit" name="Submit" value="Logar">
					</form>
					<br/>
					<br/>
					<?php
						if($_SESSION['erro'] == 1){
					?>
							<div class="alert-danger alert">RM e/ou senha incorretos!</div>
					<?php $S_SESSION['erro']=0; } ?>
					
					<?php
						if($_SESSION['erro'] == 2){
					?>
							<div class="alert-danger alert">Página restrita, efetue login</div>
					<?php } ?>
					
				</div>
			<?php
				require_once "includes/foot.php";			
			?>
		</div>
	</body>
</html>















