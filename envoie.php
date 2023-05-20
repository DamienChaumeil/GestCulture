<?php
$data = json_decode(file_get_contents('php://input') ?? "{}");

$listExploitations = $data->{'exploitations'} ?? [];
$listReturn = [];
// Vérifier si les données JSON sont valides
if (!count($listExploitations)) {
    // Les données JSON sont invalides
    $listReturn[] = "Erreur : le format JSON est invalide.";
    file_put_contents('sortie.txt', json_encode($listReturn));
    exit;
}

// Connexion à la base de données
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "gestculture";

$conn = new mysqli($servername, $username, $password, $dbname);

// Vérifier la connexion à la base de données
if ($conn->connect_error) {
    $listReturn[] = "Erreur : connection à a la base de donnée échoué.";
    file_put_contents('sortie.txt', json_encode($listReturn));
    exit;
}

foreach ($listExploitations as $key => $exploitation) {
    $Code_exploi = $exploitation->{'Code_exploi'} ?? "";
    $Nom = $exploitation->{'Nom'} ?? "";
    $Prenom = $exploitation->{'Prenom'} ?? "";
    $listParcelles = $exploitation->{'Parcelles'} ?? [];

    if ($Code_exploi == "") {
        $listReturn[] = "Erreur : Code_exploi invalide a l'index {$key}";
        continue;
    }

    $exploitations = getExploitation($conn, $Code_exploi);
    if (Count($exploitations)) {
        $Id_exploi = intval($exploitations[0]['Id_exploi'] ?? 0);
        $ancienNom = $exploitations[0]['Nom'] ?? "";
        $ancienPrenom = $exploitations[0]['Prenom'] ?? "";

        if ($ancienNom != $Nom || $ancienPrenom != $Prenom) {
            UpdateExploitation($conn, $Id_exploi, $Nom, $Prenom);
        }
    }
    else {
        $Id_exploi = insertExploitation($conn, $Code_exploi, $Nom, $Prenom);
    }
    $Id_exploi = intval($Id_exploi);
    foreach ($listParcelles as $key_parc => $parcelle) {
        $Code_parc = $parcelle->{'Code_parc'} ?? "";
        $Espece = $parcelle->{'Espece'} ?? "";
        $Surface = $parcelle->{'Surface'} ?? null;
        $Rendement_prev = $parcelle->{'Rendement_prev'} ?? null;
        $Rendement_reel = $parcelle->{'Rendement_reel'} ?? null;
        $Annee = $parcelle->{'Annee'} ?? null;
    
        if ($Code_parc == "") {
            $listReturn[] = "Erreur : Code_exploi invalide a l'index {$key}";
            continue;
        }
    
        $listReturn[] = $Id_exploi;
        file_put_contents('sortie.txt', json_encode($listReturn));
        $parcelles = getParcelle($conn, $Code_parc, $Id_exploi);
        
        if (Count($parcelles)) {
            $Id_parc = intval($parcelles[0]['Id_parc'] ?? 0);
            $ancienEspece = $parcelles[0]['Espece'] ?? "";
            $ancienSurface = $parcelles[0]['Surface'] ?? "";
            $ancienRendement_prev = $parcelles[0]['Rendement_prev'] ?? null;
            $ancienRendement_reel = $parcelles[0]['Rendement_reel'] ?? null;
            $ancienAnnee = $parcelles[0]['Annee'] ?? null;
    
            if ($ancienEspece != $Espece || $ancienSurface != $Surface || $ancienRendement_prev != $Rendement_prev || $ancienRendement_reel != $Rendement_reel || $ancienAnnee != $Annee) {
                UpdateParcelle($conn, $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee, $Id_exploi, $Id_parc);
            }
        }
        else {
            $Id_exploi = insertParcelle($conn, $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee, $Id_exploi);
        }
    }
}
file_put_contents('sortie.txt', json_encode($listReturn));

function getExploitation($conn, $Code_exploi) {
    $exec_exploit = $conn->prepare("SELECT Id_exploi, Code_exploi, Nom, Prenom FROM exploitation WHERE Code_exploi = ?");
    $exec_exploit->bind_param("s", $Code_exploi);
    $exec_exploit->execute();
    $result = $exec_exploit->get_result();
    return $result->fetch_all(MYSQLI_ASSOC);
}
function insertExploitation($conn, $Code_exploi, $Nom, $Prenom) {
    $exec_exploit = $conn->prepare("INSERT INTO exploitation (Code_exploi, Nom, Prenom) VALUES (?, ?, ?)");
    $exec_exploit->bind_param("sss", $Code_exploi, $Nom, $Prenom);
    $exec_exploit->execute();
    return $exec_exploit->insert_id;
}
function UpdateExploitation($conn, $Id_exploi, $Nom, $Prenom) {
    $exec_exploit = $conn->prepare("UPDATE exploitation SET Nom = ?, Prenom = ? WHERE Id_exploi = ?");
    $exec_exploit->bind_param("ssi", $Nom, $Prenom, $Id_exploi);
    $exec_exploit->execute();
}

function getParcelle($conn, $Code_parc, $Id_exploi) {
    $exec_parcelle = $conn->prepare("SELECT Id_parc, Espece, Surface, Rendement_prev, Rendement_reel, Annee FROM parcelle WHERE Code_parc = ? AND Id_exploi = ?");
    $exec_parcelle->bind_param("si", $Code_parc, $Id_exploi);
    $exec_parcelle->execute();
    $result = $exec_parcelle->get_result();
    return $result->fetch_all(MYSQLI_ASSOC);
}
function insertParcelle($conn, $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee, $Id_exploi) {
    $exec_parcelle = $conn->prepare("INSERT INTO parcelle (Id_exploi, Code_parc, Espece, Surface, Rendement_prev, Rendement_reel, Annee) VALUES (?, ?, ?, ?, ?, ?, ?)");
    $exec_parcelle->bind_param("issddds", $Id_exploi, $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee);
    $exec_parcelle->execute();
    return $exec_parcelle->insert_id;
}
function UpdateParcelle($conn, $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee, $Id_exploi, $Id_parc) {
    $exec_parcelle = $conn->prepare("UPDATE parcelle SET Code_parc = ?, Espece = ?, Surface = ?, Rendement_prev = ?, Rendement_reel = ?, Annee = ? WHERE Id_exploi = ? AND Id_parc = ?");
    $exec_parcelle->bind_param("ssdddsii", $Code_parc, $Espece, $Surface, $Rendement_prev, $Rendement_reel, $Annee, $Id_exploi, $Id_parc);
    $exec_parcelle->execute();
}

?>