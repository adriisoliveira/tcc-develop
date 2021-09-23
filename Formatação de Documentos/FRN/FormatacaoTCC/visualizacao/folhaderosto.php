<?php
SESSION_START();
require_once('../../conexao.php');

$titulo = isset($_POST['titulo']) ? $_POST['titulo'] : 'não informado';
$subtitulo = isset($_POST['subtitulo']) ? $_POST['subtitulo'] : 'não informado';
$orientador1 = isset($_POST['orientador1']) ? $_POST['orientador1'] : 'não informado';
$orientador2 = isset($_POST['orientador2']) ? $_POST['orientador2'] : 'não informado';
$ano = isset($_POST['ano']) ? $_POST['ano'] : 'não informado';
$cidade = isset($_POST['cidade']) ? $_POST['cidade'] : 'não informado';

$id = (isset($_POST['id']) && !empty($_POST['id'])) ? (int)$_POST['id'] : null;

if(!empty($id)) {
    $sql = "UPDATE trabalhos SET 
    tr_titulo='$titulo', 
    tr_subtitulo='$subtitulo', 
    tr_orientador1='$orientador1',
    tr_orientador2='$orientador2',
    tr_cidade='$cidade',
    tr_ano='$ano' WHERE tr_id='$id'";

    mysqli_query($conn, $sql)or die(mysqli_error($conn));
}else{
    $sql = "INSERT INTO trabalhos SET 
    tr_aluno='{$_SESSION['aluno']['id']}',
    tr_titulo='$titulo', 
    tr_subtitulo='$subtitulo', 
    tr_orientador1='$orientador1',
    tr_orientador2='$orientador2',
    tr_cidade='$cidade',
    tr_ano='$ano'";

    mysqli_query($conn, $sql)or die(mysqli_error($conn));
}

?>
<!DOCTYPE html>
<html lang="pt-br">
    <head>
    <!-- Meta tags Obrigatórias -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/Style220619.css" />

    <title>Folha de Rosto</title>
    </head>
<body>
    <header class="d-print-none">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="mt-3 mb-2 text-center">
                        <a href="../tcc.php" class="btn btn-outline-info">Voltar</a>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <main>
        <section>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <?php
                            echo '<center><div class="divPrincipal">';
                            echo '<div class="titulodotcc"><strong>' . $titulo . '</strong></div>' ;
                            echo '<div class="subtitulodotcc2">' . $subtitulo . '</div>';
                            echo '<div class="textinholateral"> <p>Trabalho de Conclusão de Curso apresentado à ETEC Prof.<p></div>
                                <div class="textinholateral"><P>Horácio Augusto da Silveira para obtenção do título de</p></div>
                                <div class="textinholateral"><p>Técnico em Informática sob orientação dos professores: </p></div>';
                            echo '<div class="lat"><strong>' . $orientador1 .  '</strong></div>';
                            echo '<div class="lat2"><strong>' . $orientador2 . '</strong></div>';
                            echo '<div class="cidadeestado">' . $cidade . '</div>';
                            echo '<div class="ano">' . $ano . '</div>.';
                            echo '</div></center>';
                        ?>
                    </div>
                </div>
            </div>
        </section>
    </main>
</body>
</html>