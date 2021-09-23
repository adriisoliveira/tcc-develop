<div class="form">Insira JUSTIFICATIVA</div>
	
	<form method="POST" action= "visualizacao/justificativa.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
		<div class="formulario">  
			<textarea name="justificativa" class="ckeditor">
				<?php isset($ju) ? print $ju : false; ?>
			</textarea> 
			<br/><br/>
		</div>

		<input class="botao2" type="submit" value="Cadastrar">
</form>