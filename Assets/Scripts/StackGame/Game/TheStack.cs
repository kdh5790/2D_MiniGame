using UnityEngine;

public class TheStack : MonoBehaviour
{
    // Const Value
    private const float BoundSize = 3.5f; // ��� ������
    private const float MovingBoundsSize = 3f; // ����� �̵��ϴ� ��
    private const float StackMovingSpeed = 5.0f; // ������Ʈ�� �̵��ϴ� �ӵ�
    private const float BlockMovingSpeed = 3.5f; // ����� �̵��ϴ� �ӵ�
    private const float ErrorMargin = 0.1f; // ����� ��� ��������

    public GameObject originBlock = null; // ������ ��� ������

    private Vector3 prevBlockPosition; // ���� ����� ��ġ
    private Vector3 desiredPosition; // �̵��ؾ��� ��ġ
    private Vector3 stackBounds = new Vector2(BoundSize, BoundSize); // ���� �� ���(������)�� ������

    Transform lastBlock = null; // ���������� ������ ���
    float blockTransition = 0f; // ��� �̵� ���� ��
    float secondaryPosition = 0f; // ���� ��ġ ��(X�� Ȥ�� Z��);

    // ���� ��� �� / ����
    int stackCount = -1;
    public int Score { get { return stackCount; } }

    // �޺�
    int comboCount = 0;
    public int Combo { get { return comboCount; } }

    // �ִ� �޺�
    private int maxCombo = 0;
    public int MaxCombo { get => maxCombo; }

    public Color prevColor; // ���� ����
    public Color nextColor; // ���� ����

    bool isMovingX = true; // X �̵� ���� (false��� Z�� �̵�)

    // �ִ� ���� / �޺�
    int bestScore = 0;
    public int BestScore { get => bestScore; }

    int bestCombo = 0;
    public int BestCombo { get => bestCombo; }

    // PlayerPrefs���� ����� Ű
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
        // ������ ����
        if (lastBlock != null)
            prevBlockPosition = lastBlock.localPosition;

        // ������ ����� ����
        GameObject newBlock = null;
        Transform newTrans = null;

        // ��� ����
        newBlock = Instantiate(originBlock);

        // ��ϵ� ���(������)�� ���ٸ�
        if (newBlock == null)
        {
            Debug.Log("NewBlock Instantiate Failed!");
            return false;
        }

        // �� ����
        ColorChange(newBlock);

        // ������ ��� �θ�, ��ġ, ȸ����, ������ ����
        newTrans = newBlock.transform;
        newTrans.parent = this.transform;
        newTrans.localPosition = prevBlockPosition + Vector3.up;
        newTrans.localRotation = Quaternion.identity;
        newTrans.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

        // ���� ��� �� �߰�
        stackCount++;

        // ��ǥ ��ġ ������Ʈ, ��� �̵� ������ �ʱ�ȭ
        desiredPosition = Vector3.down * stackCount;
        blockTransition = 0f;

        lastBlock = newTrans;

        // �̵� ���� ��ȯ
        isMovingX = !isMovingX;
        StackUIManager.Instance.UpdateScore();
        return true;
    }

    // ������ �÷��� �̱�
    Color GetRandomColor()
    {
        float r = Random.Range(100f, 250f) / 255f;
        float g = Random.Range(100f, 250f) / 255f;
        float b = Random.Range(100f, 250f) / 255f;

        return new Color(r, g, b);
    }

    // �Ű�����(GameObject)�� ���� ����
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
        // ��� �̵��� ���� ���� �� ����
        blockTransition += Time.deltaTime * BlockMovingSpeed;

        // ����� �պ����� �̵��� ��ġ ���?
        float movePosition = Mathf.PingPong(blockTransition, BoundSize) - BoundSize / 2;

        if (isMovingX)
        {
            // X������ �̵�
            lastBlock.localPosition = new Vector3(movePosition * MovingBoundsSize, stackCount, secondaryPosition);
        }
        else
        {
            // Z������ �̵�
            lastBlock.localPosition = new Vector3(secondaryPosition, stackCount, -movePosition * MovingBoundsSize);
        }
    }

    bool PlaceBlock()
    {
        // ������ ����� ���� ��ġ ���
        Vector3 lastPosition = lastBlock.transform.localPosition;

        if (isMovingX)
        {
            // ���� ��ϰ� ���� ����� X�� ����
            float deltaX = prevBlockPosition.x - lastPosition.x;

            // ������ ������ ������ ���ϱ� ���� bool ��
            bool isNegativeNum = (deltaX < 0) ? true : false;

            // ���밪���� ����
            deltaX = Mathf.Abs(deltaX);

            // ���� �������� ũ�ٸ�
            if (deltaX > ErrorMargin)
            {
                // ���ũ���� X �� ����
                stackBounds.x -= deltaX;
                if (stackBounds.x <= 0)
                {
                    return false;
                }

                // ���ο� �����ġ�� �߰���ġ ���?
                float middle = (prevBlockPosition.x + lastPosition.x) / 2;
                // ��� ũ�� ����
                lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                // ��� ��ġ ����
                Vector3 tempPosition = lastBlock.localPosition;
                tempPosition.x = middle;
                lastBlock.localPosition = lastPosition = tempPosition;

                // ����(�߷����� ���) ����
                float rubbleHalfScale = deltaX / 2;

                // isNegativeNum�� ���¿� ���� �߽���(X��) ����
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
        // ���� ���� �� ũŰ, ��ġ, ȸ���� ����
        GameObject go = Instantiate(lastBlock.gameObject);
        go.transform.parent = this.transform;

        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.transform.localRotation = Quaternion.identity;

        // ����Ʈ���� ���� Rigidbody �߰�
        go.AddComponent<Rigidbody>();
        go.name = "Rubble";
    }

    // �޺� �߰� �� �ִ� �޺� üũ
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

    // ���� üũ
    void UpdateScore()
    {
        if (bestScore < stackCount)
        {
            Debug.Log("�ְ� ���� ����");
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

            // ������ ������Ʈ ��������
            GameObject go =
                this.transform.GetChild(childCount - i).gameObject;

            if (go.name.Equals("Rubble"))
                continue;

            // Rigidbody �߰� �� ������ ������ ���� �־� ��ϵ��� ����Ʈ��
            Rigidbody rigid = go.AddComponent<Rigidbody>();

            rigid.AddForce(
                (Vector3.up * Random.Range(0, 10f)
                 + Vector3.right * (Random.Range(0, 10f) - 5f))
                * 100f
            );
        }
    }

    // ���� ������� ���� �ʱ�ȭ
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