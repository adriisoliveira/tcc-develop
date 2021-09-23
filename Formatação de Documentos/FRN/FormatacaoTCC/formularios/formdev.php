<div class="form">Insira os dados de DESENVOLVIMENTO</div>
	
	<form method="POST" action= "visualizacao/dev.php" >
		<input type="hidden" name="id" value="<?=isset($id) ? $id : false?>">
		<div class="formulario">  
			<textarea name="dev" class="ckeditor">
				<?php isset($de) ? print $de : false; ?>
			</textarea> 
			<br/><br/>
		</div>

		<input class="botao2" type="submit" value="Cadastrar">
</form>