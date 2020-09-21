<?php
if($_POST){
	$ara=$_POST['ara'];

$ara=str_replace(' ',"+", $ara);
$sayfa='1';

$veri_al=file_get_contents('http://1337x.to/search/'.$ara.'/'.$i.'/');
$bat='@<strong><a href="(.*?)">(.*?)</a></strong>@';
$bat2='@<span class="green">(.*?)</span>@';
$bat3='@<span class="red">(.*?)</span>@';
$bat4='@<div class="coll-4"><span>(.*?)</span></div>@';
$bat5='@<div class="coll-5 (.*?)"><span><a href="(.*?)">(.*?)</a></span></div@';
$bat6='@<li class="last"><a href="/search/(.*?)/">Last</a></li>@';

preg_match_all($bat, $veri_al, $veri_derece);
preg_match_all($bat2, $veri_al, $se);
preg_match_all($bat3, $veri_al, $le);
preg_match_all($bat4, $veri_al, $size);
preg_match_all($bat5, $veri_al, $uploader);
preg_match_all($bat6, $veri_al, $last);

$row=count($veri_derece[2]);

$at=explode('/',implode($last[1]));

/*
echo '<pre>';
print_r($at[1]);
echo '</pre>';
*/
echo '<table windth="900" border="1">';

echo '<tr>';
echo '<td>Name</td>';
echo '<td>Se</td>';
echo '<td>Le</td>';
echo '<td>Size</td>';
echo '<td>UpLoader</td>';
echo '</tr>';

for ($i=0; $i <$row ; $i++) {
?>

<tr>
<td><?php echo $veri_derece[2][$i] ?></td>
<td><?php echo $se[0][$i] ?></td>
<td><?php echo $le[0][$i] ?></td>
<td><?php echo $size[1][$i] ?></td>
<td><?php echo $uploader[3][$i] ?></td>
</tr>

<?php 
}

echo '<tr><td>'; 

for ($i=1; $i <= $at[1] ; $i++) { 
echo '<button type="button">';
echo $i;
echo '</button>';
echo ' ';
}

echo '</td></tr>';

echo '</table>';
}else{
	echo'
<form action="" method="POST">
<input type="text" name="ara" placeholder="name gir"/><br>
<input type="submit" value="aratan bulur"/>
</form>';
	 }


?>