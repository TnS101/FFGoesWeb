let playerHealth = document.getElementById("playerHealth");
let enemyHealth = document.getElementById("enemyHealth");
let playerDamage = document.getElementById("playerDamage");
let enemyDamage = document.getElementById("enemyDamage");
playerHealth.value -= enemyDamage.value;
enemyHealth.value -= playerDamage.value;