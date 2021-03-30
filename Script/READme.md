# The Game Specificity

## Access

OS X & Linux & Windows by a Launcher:

## Setup For Development

In order to complete the project, it would have been necessary to install UnityHub or directly UNITY2019
```c#
using UnityEngine;
```
### Conception :

> Le SingleTone : 
```c#
private void Awake()
    {
        if (myOwnInventory != null)
        {
            Debug.LogWarning("Il y a déjà un inventaire dans la session");
        }
        myOwnInventory = this;
    }
```
> Très pratique pour créer un seul objet unique static(comme l'inventaire) et d'utiliser ses méthodes dans d'autres script. 
>> ![Capture d’écran 2021-03-29 à 20 34 24](https://user-images.githubusercontent.com/71081511/112884307-a709cf00-90cf-11eb-868e-11b6b39fdf50.png)

> Les Zones :
**https://github.com/Mbourdon95/2D_PLATFORMER_UNITY19/new/main/Script/Zone**


## Meta

Bourdon Maxime – Mbourdon.pro@gmail.com

[https://github.com/Mbourdon95/github-link](https://github.com/Mbourdon95/)



