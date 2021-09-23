<?php
	session_start();
	
	require_once "conexao.php";
	




	$user = $_POST['RM'];
	$pass = md5($_POST[('senha')]);
	$sql = mysqli_query($conn,"SELECT * FROM aluno WHERE rm = '$user' AND senha = '$pass'");
	$sqladmin = mysqli_query($conn,"SELECT * FROM administrador WHERE conta_admin = '$user' AND senha_admin= '$pass'");
	
	$rsadmin=mysqli_fetch_array($sqladmin);
	$rsusuario = mysqli_fetch_array($sql);
	echo $rsusuario['nm_aluno'];
	if($user==$rsadmin['conta_admin'] && $pass==$rsadmin['senha_admin'])
	{
			$_SESSION['logado'] = true;
		$_SESSION['erro'] = 0;
		$_SESSION['admin']=1;
		header("location:index.php");
	}
	else{
	if($user==$rsusuario['rm'] && $pass==$rsusuario['senha']){
		$_SESSION['logado'] = true;
		$_SESSION['nome'] = $rsusuario['nm_aluno'];;
		$_SESSION['id'] = $rsusuario['id_aluno'];
		$_SESSION['erro'] = 0;
		$_SESSION['reserva'] = 1;

		if($_POST['RM'] != $_POST['senha']){
		header("location:index.php");
		}
		else{
			header("location:esqueci.php");
		}
	}
	else{
		$_SESSION['logado'] = false;
		$_SESSION['erro'] = 1;
		$_SESSION['perfil'] = 0;

		header("location:login.php");
	}
	}
	

?>