namespace FootballManager
{
    class Transfer
    {
        public Transfer(Player player, Club seller, Club buyer, int price)
        {
            if (seller.squad.players.Count > Squad.minPlayers &&
                buyer.squad.players.Count < Squad.maxPlayers &&
                buyer.finance.money >= player.value)
            {
                for (int i = 0; i < seller.squad.players.Count; i++)
                {
                    if (seller.squad.players[i] == player)
                    {
                        seller.squad.players.RemoveAt(i);
                        seller.finance.saleOfPlayers += player.value;
                    }
                }

                buyer.squad.players.Add(player);
                buyer.finance.purchaseOfPlayers += player.value;

                player.clubId = buyer.id;
            }
        }
    }
}
