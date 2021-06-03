import * as alt from 'alt-client';

alt.onServer('Blips:Synchronize', (blips) => {
    blips = JSON.parse(blips);
    for (var i in blips) {
        createBlip(blips[i]);
    }
});

function createBlip(blipData) {
    const blip = new alt.PointBlip(blipData.PosX, blipData.PosY, blipData.PosZ);
    blip.sprite = blipData.Type;
    blip.color = blipData.Color;
    blip.shortRange = blipData.ShortRange;
    blip.name = blipData.Name;
}