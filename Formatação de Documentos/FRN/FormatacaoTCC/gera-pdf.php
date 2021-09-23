<?php
SESSION_START();
require_once('../conexao.php');
require_once('mpdf7/autoload.php');

ini_set('memory_limit', '-1');

$sql = "SELECT * FROM trabalhos WHERE tr_aluno='{$_SESSION['id']}'";
$trab = mysqli_query($conn, $sql);

if(mysqli_num_rows($trab) > 0) :

	$TR = mysqli_fetch_array($trab);

	$pdf = new \Mpdf\Mpdf([
        'debug'=>false,
        'mode'=>'utf-8',
        'orientation'=>'P',
        'format' => [190, 236]
    ]);

    $style = file_get_contents('visualizacao/css/Style220619.css');

    $pdf->setHTMLHeader('<div style="text-align: right; font-size: 8pt; color:#adadad;">Página {PAGENO} de {nb}</div>');
    $pdf->SetHTMLFooter('<div style="text-align: center; font-size: 9px; color:#adadad;">Data de Emissão: '.date('d/m/Y').'</div>');


    $htmlCapa = '
    <center><div class="divPrincipal">
    <div class="nomedainstituicao"><strong>' . $TR['tr_instituicao'] . '</strong></div>
    <div class="titulodotcc"><strong>' . $TR['tr_titulo'] . '</strong></div>
    <div class="subtitulodotcc">' . $TR['tr_subtitulo'] . '</div>
    <div class="nomedointegrante1">' . $TR['tr_integrante1'] . '</div>
    <div class="nomedointegrante">' . $TR['tr_integrante2'] . '</div>
    <div class="nomedointegrante">' . $TR['tr_integrante3'] . '</div>
    <div class="nomedointegrante">' . $TR['tr_integrante4'] . '</div>
    <div class="nomedointegrante">' . $TR['integrante5'] . '</div>
    <div class="cidadeestado">' . $TR['tr_cidade'] . '</div>
    <div class="ano">' . $TR['tr_ano'] . '</div></div></center>
    ';

    $pdf->WriteHTML($style, 1);
    $pdf->WriteHTML($htmlCapa, 2);
        
    $htmlFolha = '<center><div class="divPrincipal">
    <div class="titulodotcc"><strong>' . $TR['tr_titulo'] . '</strong></div>
    <div class="subtitulodotcc2">' . $TR['tr_subtitulo'] . '</div>
    <div class="textinholateral"> <p>Trabalho de Conclusão de Curso apresentado à ETEC Prof.<p></div>
        <div class="textinholateral"><P>Horácio Augusto da Silveira para obtenção do título de</p></div>
        <div class="textinholateral"><p>Técnico em Informática sob orientação dos professores: </p></div>
    <div class="lat"><strong>' . $TR['tr_orientador1'] .  '</strong></div>
    <div class="lat2"><strong>' . $TR['tr_orientador2'] . '</strong></div>
    <div class="cidadeestado">' . $TR['tr_cidade'] . '</div>
    <div class="ano">' . $TR['tr_ano'] . '</div>
    </div></center>';

    $pdf->addPage();
    $pdf->WriteHTML($style, 1);
    $pdf->WriteHTML($htmlFolha, 2);

    if(isset($TR['tr_sumario']) && !empty($TR['tr_sumario'])) {
        $pdf->addPage();
        $pdf->WriteHTML($TR['tr_sumario']);
    }

    if(isset($TR['tr_introducao']) && !empty($TR['tr_introducao'])) {
        $pdf->addPage();
        $pdf->WriteHTML($TR['tr_introducao']);
    }

    if(isset($TR['tr_justificativa']) && !empty($TR['tr_justificativa'])) {
        $pdf->addPage();
        $pdf->WriteHTML($TR['tr_justificativa']);
    }

    if(isset($TR['tr_dev']) && !empty($TR['tr_dev'])) {
        $pdf->addPage();
        $pdf->WriteHTML($TR['tr_dev']);
    }

    if(isset($TR['tr_bibliografia']) && !empty($TR['tr_bibliografia'])) {
        $pdf->addPage();
        $pdf->WriteHTML($TR['tr_bibliografia']);
    }

	$pdf->Output('trabalho-tcc-'.date('Y-m-d').'.pdf', 'D');

else :
	echo 'Nenhum trabalho encontrado.<br><a href="tcc.php">Voltar</a>';
endif;
?>