using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public GameData currentGameData;

    private string _word;

    private int _assignPoints = 0;
    private int _complateWords = 0;
    private Ray rayUp, rayDown;
    private Ray rayLeft, rayRight;
    private Ray rayDiagonalLeftUp, RayDiagonalLeftDown;
    private Ray rayDiagonalRightUp, RayDiagonalRightDown;
    private Vector3 _rayStartPosition;
    private Ray currentRay=new Ray();
    private List<int> correctList = new List<int>();

    public int x;
    private void OnEnable()
    {
        GameEvent.OnChecksquare += SquareSelected;
        GameEvent.OnClearSelect += clearslection;
    }
    private void OnDisable()
    {
        GameEvent.OnChecksquare -= SquareSelected;
        GameEvent.OnClearSelect+= clearslection;
    }
    void Start()
    {
        x = currentGameData.selectBoardData.searchingWords.Count;
        _assignPoints = 0;
        _complateWords = 0;
    }

    void Update()
    {
        CheckBoard();
        if (_assignPoints>0&&Application.isEditor)
        {
            Debug.DrawRay(rayUp.origin, rayUp.direction * 4);
            Debug.DrawRay(rayDown.origin, rayDown.direction * 4);
            Debug.DrawRay(rayLeft.origin, rayLeft.direction * 4);
            Debug.DrawRay(rayRight.origin, rayRight.direction * 4);
            Debug.DrawRay(rayDiagonalLeftUp.origin, rayDiagonalLeftUp.direction * 4);
            Debug.DrawRay(RayDiagonalLeftDown.origin, RayDiagonalLeftDown.direction * 4);
            Debug.DrawRay(rayDiagonalRightUp.origin, rayDiagonalRightUp.direction * 4);
            Debug.DrawRay(RayDiagonalRightDown.origin, RayDiagonalRightDown.direction * 4);
        }
    }
    private void SquareSelected(string Letter, Vector3 squareposition, int squareIndex) 
    {
        if (_assignPoints==0)
        {
            _rayStartPosition = squareposition;
            correctList.Add(squareIndex);
            _word += Letter;

            rayUp = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(0, 1));
            rayDown = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(0, -1));
            rayLeft = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(-1,0));
            rayRight = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(1,0)); 
            rayDiagonalLeftUp = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(-1,1)); 
            RayDiagonalLeftDown = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(-1,-1)); 
            rayDiagonalRightUp = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(1,1)); 
            RayDiagonalRightDown = new Ray(new Vector2(squareposition.x, squareposition.y), new Vector2(1,-1)); 
        }
        else if (_assignPoints==1)
        {
            correctList.Add(squareIndex);
            currentRay = SelectRay(_rayStartPosition,squareposition);
            GameEvent.selectSquareMethod(squareposition);
            _word += Letter;
            checkWord();
        }
        else
        {
            if (IsPointOnTheRay(currentRay,squareposition))
            {
                correctList.Add(squareIndex);
                GameEvent.selectSquareMethod(squareposition);
                _word += Letter;
                checkWord();
            }
        }
        _assignPoints++;
    }
    private void checkWord() 
    {
        foreach (var serchingWord in currentGameData.selectBoardData.searchingWords)
        {
            if (_word==serchingWord.word)
            {
                GameEvent.correctWordMethod(_word, correctList);
                x -= 1;
                print(x);
                _word = string.Empty;
                return;
            }
        }
    }

    private bool IsPointOnTheRay(Ray currentRay,Vector3 point) 
    {
        var hits = Physics.RaycastAll(currentRay, 100.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.position==point)
            {
                return true;
            }
        }
        return false;
    }
    private Ray SelectRay(Vector2 firstPosition,Vector2 secondPosition) 
    {
        var direction = (secondPosition - firstPosition).normalized;
        float tolerance = 0.01f;
        if (Mathf.Abs(direction.x)<tolerance&&Mathf.Abs(direction.y-1f)<tolerance)
        {
            return rayUp;
        }
        if (Mathf.Abs(direction.x)<tolerance&&Mathf.Abs(direction.y+1f)<tolerance)
        {
            return rayDown;
        }
        if (Mathf.Abs(direction.x+1f)<tolerance&&Mathf.Abs(direction.y)<tolerance)
        {
            return rayLeft;
        }
        if (Mathf.Abs(direction.x-1f)<tolerance&&Mathf.Abs(direction.y)<tolerance)
        {
            return rayRight;
        }
        if (direction.x<0f&&direction.y>0f)
        {
            return rayDiagonalLeftUp;
        }
        if (direction.x<0f&&direction.y<0f)
        {
            return RayDiagonalLeftDown;
        }
        if (direction.x>0f&&direction.y<0f)
        {
            return RayDiagonalRightDown;
        }
        if (direction.x>0f&&direction.y>0f)
        {
            return rayDiagonalRightUp;
        }

        return rayDown;
    }
    private void clearslection() 
    {
        _assignPoints = 0;
        correctList.Clear();
       
        _word = string.Empty;
    }
    private void CheckBoard() 
    {

        if (x==_complateWords)
        {
            print("sukses");
        }
    }
}
