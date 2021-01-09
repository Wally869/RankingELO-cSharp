public static class RankingELO {
  // returns probability of winning for player 1
  public static float GetProbabilityWinning(float ratingPlayer1, float ratingPlayer2) {
    return 1f / (1f + Mathf.Pow(10f, (ratingPlayer2 - ratingPlayer1) / 400f));
  }

  public static void UpdatePlayerRankings(float ratingPlayer1, float ratingPlayer2, float multiplier, bool isPlayer1Winner) {

    float probabilityWinPlayer1 = GetProbabilityWinning(ratingPlayer1, ratingPlayer2);

    if (isPlayer1Winner) {
      ratingPlayer1 += multiplier * (1 - probabilityWinPlayer1);
      ratingPlayer2 += multiplier * (probabilityWinPlayer1 - 1);
      
    } else {
      ratingPlayer1 += multiplier * (- probabilityWinPlayer1);
      ratingPlayer2 += multiplier * probabilityWinPlayer1
    }
  }

}
