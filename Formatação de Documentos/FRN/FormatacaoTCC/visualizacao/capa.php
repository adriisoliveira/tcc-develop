<?php
 SESSION_START();
 require_once "../../conexao.php";

$titulo = isset($_POST['titulo']) ? $_POST['titulo'] : 'não informado';
$subtitulo = isset($_POST['subtitulo']) ? $_POST['subtitulo'] : 'não informado';
$instituicao = isset($_POST['instituicao']) ? $_POST['instituicao'] : 'não informado';
$integrante1 = isset($_POST['integrante1']) ? $_POST['integrante1'] : 'não informado';
$integrante2 = isset($_POST['integrante2']) ? $_POST['integrante2'] : 'não informado';
$integrante3 = isset($_POST['integrante3']) ? $_POST['integrante3'] : 'não informado';
$integrante4 = isset($_POST['integrante4']) ? $_POST['integrante4'] : 'não informado';
$integrante5 = isset($_POST['integrante5']) ? $_POST['integrante5'] : 'não informado';
$ano = isset($_POST['ano']) ? $_POST['ano'] : 'não informado';
$cidade = isset($_POST['cidade']) ? $_POST['cidade'] : 'não informado';


$id = (isset($_POST['id']) && !empty($_POST['id'])) ? (int)$_POST['id'] : null;

if(!empty($id)) {
    $sql = "UPDATE trabalhos SET 
    tr_titulo='$titulo', 
    tr_subtitulo='$subtitulo', 
    tr_instituicao='$instituicao',
    tr_integrante1='$integrante1',
    tr_integrante2='$integrante2',
    tr_integrante3='$integrante3',
    tr_integrante4='$integrante4',
    tr_integrante5='$integrante5',
    tr_cidade='$cidade',
    tr_ano='$ano' WHERE tr_id='$id'";

    mysqli_query($conn, $sql)or die(mysqli_error($conn));
}else{

    $sql = "INSERT INTO trabalhos SET 
    tr_aluno='{$_SESSION['id']}',
    tr_titulo='$titulo', 
    tr_subtitulo='$subtitulo', 
    tr_instituicao='$instituicao',
    tr_integrante1='$integrante1',
    tr_integrante2='$integrante2',
    tr_integrante3='$integrante3',
    tr_integrante4='$integrante4',
    tr_integrante5='$integrante5',
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

    <title>Capa</title>
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
                            echo '<div class="nomedainstituicao">' . $instituicao . '</div>';
                            echo '<div class="titulodotcc">' . $titulo . '</div>' ;
                            echo '<div class="subtitulodotcc">' . $subtitulo . '</div>';
                            echo '<div class="nomedointegrante1">' . $integrante1 . '</div>';
                            echo '<div class="nomedointegrante">' . $integrante2 . '</div>';
                            echo '<div class="nomedointegrante">' . $integrante3 . '</div>';
                            echo '<div class="nomedointegrante">' . $integrante4 . '</div>';
                            echo '<div class="nomedointegrante">' . $integrante5 . '</div>';
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