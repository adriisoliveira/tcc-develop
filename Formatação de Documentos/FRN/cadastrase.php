<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>FRN-Formatação Rápida nas Normas</title>

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet">

    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="style.css">
    <link rel="stylesheet" href="responsive.css">
    <style type="text/css">
    body {
    background-color: #fff;
}
    </style>
</head>

<body>
	
	<form action="?acao=cadastro" method="POST">
		<label>Digite seu nome: </label></br>
		<input type="text" name="nomeuser" required></br></br>
		<label>Digite seu E-Mail: </label></br>
		<input type="text" name="emailuser" required placeholder="Seu email será seu login"></br></br>
		<label>Digite sua senha: </label>
		<input type="text" required></br></br>
		<label>Digite sua novamente senha: </label>
		<input type="text" name="senha" required></br>
		<button type="submit">Cadastrar</button>
	</form>

	<?php
	require_once('conexao.php');

	if(isset($_GET['acao']) && $_GET['acao']=='cadastro') {

		$nome = filter_input(INPUT_POST, 'nomeuser', FILTER_SANITIZE_FULL_SPECIAL_CHARS);
		$email = filter_input(INPUT_POST, 'emailuser', FILTER_SANITIZE_EMAIL);
		$senha = filter_input(INPUT_POST, 'senha', FILTER_DEFAULT);

		if(!empty($email) && !empty($senha)) {

			$check = mysqli_query($conn, "SELECT email FROM aluno WHERE email='$email'");
			if(mysqli_num_rows($check) > 0) {
				die('<br><br><hr><h3>ATENÇÃO: Email já cadastrado em nosso sistema, escolha outro.</h3>');
			}

			$senha = md5($senha);

			$sql = "INSERT INTO aluno SET rm=0, nm_aluno='$nome', email='$email', senha='$senha'";
			$ok = mysqli_query($conn, $sql)or die(mysqli_error($conn));
			if($ok) {

				$assunto = 'Confirmação de Cadastro';
				$msg = 'Olá <strong>'.$nome.'</strong>, <a href="'.$URL_BASE.'/confirmaCadastro.php?token='.$senha.'">clique aqui</a> para confirmar seu cadastro!';
				$destinatario = $email;

				// To send HTML mail, the Content-type header must be set
				$headers  = 'MIME-Version: 1.0' . "\r\n";
				$headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";

				// Additional headers
				$headers .= 'To: '.$nome.' <'.$email.'>' . "\r\n";
				mail($destinatario, $assunto, $msg, $headers);

				echo '<br><br><hr><h3>Aluno cadastrado com sucesso.<br>Verifique sua caixa de entrada para confirmar o seu cadastro.</h3>';

			}
		}

	}
	?>

</body>
</html>