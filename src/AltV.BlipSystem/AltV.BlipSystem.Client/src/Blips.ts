import { onServer, PointBlip } from 'alt-client';

onServer('Blips:Synchronize', (blips: string) => {
    let convertedBlips: any = JSON.parse(blips);
    for (var i in convertedBlips) {
        createBlip(convertedBlips[i]);
    }
});

function createBlip(blipData: any) {
    const blip = new PointBlip(blipData.PosX, blipData.PosY, blipData.PosZ);
    blip.sprite = blipData.Type;
    blip.color = blipData.Color;
    blip.shortRange = blipData.ShortRange;
    blip.name = blipData.Name;
}