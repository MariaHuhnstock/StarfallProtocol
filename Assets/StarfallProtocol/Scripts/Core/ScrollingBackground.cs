using UnityEngine;

namespace StarfallProtocol.Core
{
    /// <summary>
    /// Scrollt zwei identische Hintergrund-Sprites endlos nach unten,
    /// indem das obere Sprite jeweils oben wieder angehängt wird.
    /// Kleiner Overlap verhindert ein Flimmern/Aufblitzen der Nahtlinie.
    /// </summary>
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 2f;
        [SerializeField] private Transform[] _backgroundPieces; // 2 identische Sprites übereinander
        [SerializeField] private float _overlap = 0.05f; // in Units, gegen Flimmer-Naht

        private float _pieceHeight;

        private void Start()
        {
            SpriteRenderer sr = _backgroundPieces[0].GetComponent<SpriteRenderer>();
            _pieceHeight = sr.bounds.size.y;
        }

        private void Update()
        {
            foreach (Transform piece in _backgroundPieces)
            {
                piece.position += Vector3.down * _scrollSpeed * Time.deltaTime;

                // Sobald ein Stück komplett unten aus dem Bild ist, oben wieder anhängen.
                if (piece.position.y <= -_pieceHeight)
                {
                    float highestY = GetHighestPieceY();
                    piece.position = new Vector3(piece.position.x, highestY + _pieceHeight - _overlap, piece.position.z);
                }
            }
        }

        private float GetHighestPieceY()
        {
            float highest = float.MinValue;
            foreach (Transform piece in _backgroundPieces)
            {
                if (piece.position.y > highest) highest = piece.position.y;
            }
            return highest;
        }
    }
}