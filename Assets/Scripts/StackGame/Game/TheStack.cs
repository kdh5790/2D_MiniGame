using UnityEngine;

public class TheStack : MonoBehaviour
{
    // Const Value
    private const float BoundSize = 3.5f; // 블록 사이즈
    private const float MovingBoundsSize = 3f; // 블록이 이동하는 양
    private const float StackMovingSpeed = 5.0f; // 오브젝트가 이동하는 속도
    private const float BlockMovingSpeed = 3.5f; // 블록이 이동하는 속도
    private const float ErrorMargin = 0.1f; // 블록의 허용 오차범위

    public GameObject originBlock = null; // 생성할 블록 프리팹

    private Vector3 prevBlockPosition; // 이전 블록의 위치
    private Vector3 desiredPosition; // 이동해야할 위치
    private Vector3 stackBounds = new Vector2(BoundSize, BoundSize); // 생성 할 블록(프리팹)의 사이즈

    Transform lastBlock = null; // 마지막으로 생성된 블록
    float blockTransition = 0f; // 블록 이동 보간 값
    float secondaryPosition = 0f; // 보조 위치 값(X값 혹은 Z값);

    // 쌓인 블록 수 / 점수
    int stackCount = -1;
    public int Score { get { return stackCount; } }

    // 콤보
    int comboCount = 0;
    public int Combo { get { return comboCount; } }

    // 최대 콤보
    private int maxCombo = 0;
    public int MaxCombo { get => maxCombo; }

    public Color prevColor; // 이전 색상
    public Color nextColor; // 다음 색상

    bool isMovingX = true; // X 이동 여부 (false라면 Z축 이동)

    // 최대 점수 / 콤보
    int bestScore = 0;
    public int BestScore { get => bestScore; }

    int bestCombo = 0;
    public int BestCombo { get => bestCombo; }

    // PlayerPrefs에서 사용할 키
    private const string BestScoreKey = "BestScore";
    private const string BestComboKey = "BestCombo";

    private bool isGameOver = true;

    void Start()
    {
        if (originBlock == null)
        {
            Debug.Log("OriginBlock is NULL");
            return;
        }

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);

        prevBlockPosition = Vector3.down;
        Spawn_Block();
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (PlaceBlock())
            {
                Spawn_Block();
            }
            else
            {
                FindObjectOfType<StackRankingManager>().AddScore();
                UpdateScore();
                isGameOver = true;
                GameOverEffect();
                StackUIManager.Instance.SetScoreUI();
            }
        }

        MoveBlock();
        transform.position = Vector3.Lerp(transform.position, desiredPosition, StackMovingSpeed * Time.deltaTime);
    }

    bool Spawn_Block()
    {
        // 이전블럭 저장
        if (lastBlock != null)
            prevBlockPosition = lastBlock.localPosition;

        // 생성한 블록의 정보
        GameObject newBlock = null;
        Transform newTrans = null;

        // 블록 생성
        newBlock = Instantiate(originBlock);

        // 등록된 블록(프리팹)이 없다면
        if (newBlock == null)
        {
            Debug.Log("NewBlock Instantiate Failed!");
            return false;
        }

        // 색 변경
        ColorChange(newBlock);

        // 생성한 블록 부모, 위치, 회전값, 스케일 설정
        newTrans = newBlock.transform;
        newTrans.parent = this.transform;
        newTrans.localPosition = prevBlockPosition + Vector3.up;
        newTrans.localRotation = Quaternion.identity;
        newTrans.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

        // 쌓인 블록 수 추가
        stackCount++;

        // 목표 위치 업데이트, 블록 이동 보간값 초기화
        desiredPosition = Vector3.down * stackCount;
        blockTransition = 0f;

        lastBlock = newTrans;

        // 이동 방향 전환
        isMovingX = !isMovingX;
        StackUIManager.Instance.UpdateScore();
        return true;
    }

    // 랜덤한 컬러값 뽑기
    Color GetRandomColor()
    {
        float r = Random.Range(100f, 250f) / 255f;
        float g = Random.Range(100f, 250f) / 255f;
        float b = Random.Range(100f, 250f) / 255f;

        return new Color(r, g, b);
    }

    // 매개변수(GameObject)의 색상 변경
    void ColorChange(GameObject go)
    {
        Color applyColor = Color.Lerp(prevColor, nextColor, (stackCount % 11) / 10f);

        Renderer rn = go.GetComponent<Renderer>();

        if (rn == null)
        {
            Debug.Log("Renderer is NULL!");
            return;
        }

        rn.material.color = applyColor;
        Camera.main.backgroundColor = applyColor - new Color(0.1f, 0.1f, 0.1f);

        if (applyColor.Equals(nextColor) == true)
        {
            prevColor = nextColor;
            nextColor = GetRandomColor();
        }
    }

    void MoveBlock()
    {
        // 블록 이동을 위한 보간 값 증가
        blockTransition += Time.deltaTime * BlockMovingSpeed;

        // 블록이 왕복으로 이동할 위치 계산?
        float movePosition = Mathf.PingPong(blockTransition, BoundSize) - BoundSize / 2;

        if (isMovingX)
        {
            // X축으로 이동
            lastBlock.localPosition = new Vector3(movePosition * MovingBoundsSize, stackCount, secondaryPosition);
        }
        else
        {
            // Z축으로 이동
            lastBlock.localPosition = new Vector3(secondaryPosition, stackCount, -movePosition * MovingBoundsSize);
        }
    }

    bool PlaceBlock()
    {
        // 마지막 블록의 현재 위치 계산
        Vector3 lastPosition = lastBlock.transform.localPosition;

        if (isMovingX)
        {
            // 이전 블록과 현재 블록의 X값 차이
            float deltaX = prevBlockPosition.x - lastPosition.x;

            // 파편을 생성할 방향을 구하기 위한 bool 값
            bool isNegativeNum = (deltaX < 0) ? true : false;

            // 절대값으로 변경
            deltaX = Mathf.Abs(deltaX);

            // 오차 범위보다 크다면
            if (deltaX > ErrorMargin)
            {
                // 블록크기의 X 값 감소
                stackBounds.x -= deltaX;
                if (stackBounds.x <= 0)
                {
                    return false;
                }

                // 새로운 블록위치의 중간위치 계산?
                float middle = (prevBlockPosition.x + lastPosition.x) / 2;
                // 블록 크기 변경
                lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                // 블록 위치 변경
                Vector3 tempPosition = lastBlock.localPosition;
                tempPosition.x = middle;
                lastBlock.localPosition = lastPosition = tempPosition;

                // 파편(잘려나간 블록) 생성
                float rubbleHalfScale = deltaX / 2;

                // isNegativeNum의 상태에 따라 중심점(X값) 변경
                CreateRubble(
                    new Vector3(isNegativeNum
                            ? lastPosition.x + stackBounds.x / 2 + rubbleHalfScale
                            : lastPosition.x - stackBounds.x / 2 - rubbleHalfScale
                        , lastPosition.y
                        , lastPosition.z),
                    new Vector3(deltaX, 1, stackBounds.y)
                );

                comboCount = 0;
            }
            else
            {
                ComboCheck();
                lastBlock.localPosition = prevBlockPosition + Vector3.up;
            }
        }
        else
        {
            float deltaZ = prevBlockPosition.z - lastPosition.z;
            bool isNegativeNum = (deltaZ < 0) ? true : false;

            deltaZ = Mathf.Abs(deltaZ);
            if (deltaZ > ErrorMargin)
            {
                stackBounds.y -= deltaZ;
                if (stackBounds.y <= 0)
                {
                    return false;
                }

                float middle = (prevBlockPosition.z + lastPosition.z) / 2;
                lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                Vector3 tempPosition = lastBlock.localPosition;
                tempPosition.z = middle;
                lastBlock.localPosition = lastPosition = tempPosition;

                float rubbleHalfScale = deltaZ / 2;
                CreateRubble(
                    new Vector3(
                        lastPosition.x
                        , lastPosition.y
                        , isNegativeNum
                            ? lastPosition.z + stackBounds.y / 2 + rubbleHalfScale
                            : lastPosition.z - stackBounds.y / 2 - rubbleHalfScale),
                    new Vector3(stackBounds.x, 1, deltaZ)
                );

                comboCount = 0;
            }
            else
            {
                ComboCheck();
                lastBlock.localPosition = prevBlockPosition + Vector3.up;
            }
        }

        secondaryPosition = (isMovingX) ? lastBlock.localPosition.x : lastBlock.localPosition.z;

        return true;
    }

    void CreateRubble(Vector3 pos, Vector3 scale)
    {
        // 파편 생성 및 크키, 위치, 회전값 적용
        GameObject go = Instantiate(lastBlock.gameObject);
        go.transform.parent = this.transform;

        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.transform.localRotation = Quaternion.identity;

        // 떨어트리기 위해 Rigidbody 추가
        go.AddComponent<Rigidbody>();
        go.name = "Rubble";
    }

    // 콤보 추가 및 최대 콤보 체크
    void ComboCheck()
    {
        comboCount++;

        if (comboCount > maxCombo)
            maxCombo = comboCount;

        if ((comboCount % 5) == 0)
        {
            Debug.Log("5Combo Success!");
            stackBounds += new Vector3(0.5f, 0.5f);
            stackBounds.x =
                (stackBounds.x > BoundSize) ? BoundSize : stackBounds.x;
            stackBounds.y =
                (stackBounds.y > BoundSize) ? BoundSize : stackBounds.y;
        }
    }

    // 점수 체크
    void UpdateScore()
    {
        if (bestScore < stackCount)
        {
            Debug.Log("최고 점수 갱신");
            bestScore = stackCount;
            bestCombo = maxCombo;

            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            PlayerPrefs.SetInt(BestComboKey, bestCombo);
        }
    }

    void GameOverEffect()
    {
        int childCount = this.transform.childCount;

        for (int i = 1; i < 20; i++)
        {
            if (childCount < i)
                break;

            // 변경할 오브젝트 가져오기
            GameObject go =
                this.transform.GetChild(childCount - i).gameObject;

            if (go.name.Equals("Rubble"))
                continue;

            // Rigidbody 추가 후 랜덤한 값으로 힘을 주어 블록들을 쓰러트림
            Rigidbody rigid = go.AddComponent<Rigidbody>();

            rigid.AddForce(
                (Vector3.up * Random.Range(0, 10f)
                 + Vector3.right * (Random.Range(0, 10f) - 5f))
                * 100f
            );
        }
    }

    // 게임 재시작을 위한 초기화
    public void Restart()
    {
        int childCount = this.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

        isGameOver = false;

        lastBlock = null;
        desiredPosition = Vector3.zero;
        stackBounds = new Vector3(BoundSize, BoundSize);

        stackCount = -1;
        isMovingX = true;
        blockTransition = 0f;
        secondaryPosition = 0f;

        comboCount = 0;
        maxCombo = 0;

        prevBlockPosition = Vector3.down;

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        Spawn_Block();
        Spawn_Block();
    }
}