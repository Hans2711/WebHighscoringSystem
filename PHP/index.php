<?php
if(!$_POST["val"] && !$_POST["type"])
{
    die("error");
}
$First = file_get_contents("Stats/1");
$Second = file_get_contents("Stats/2");
$Third = file_get_contents("Stats/3");
$Type = $_POST["type"];
if($Type == "add")
{
    $val = $_POST["val"];
    if($val < $Third)
    {
        die("no change");
    }
    if($val > $First)
    {
        $Third = $Second;
        $Second = $First;
        $First = $val;
    }
    if($val < $First && $val > $Second)
    {
        $Third = $Second;
        $Second = $val;
    }
    if($val < $Second && $val > $Third)
    {
        $Third = $val;
    }
    file_put_contents("Stats/1", $First);
    file_put_contents("Stats/2", $Second);
    file_put_contents("Stats/3", $Third);
    die("updated");
}
if($Type == "get")
{
    $return = '
1:'.$First.'
2:'.$Second.'
3:'.$Third;
    die($return);

}

?>