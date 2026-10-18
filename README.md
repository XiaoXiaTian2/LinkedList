# LinkedList

## 待改進

1. **`JackList.DetectCycle` 一開始就判定有環**：`slow` 和 `fast` 都從 `Head` 出發，而迴圈第一件事就是檢查 `slow == fast`，所以只要串列不是空的，第一圈就回傳 `true`。`AddRange` 在非空串列上接上新串列後一定會走到 `lastNode.Next = null` 把它還原，等於 AddRange 永遠沒效果。修正方向：先移動 `slow`、`fast` 再比較。另外 `AddRange` 在 `Head == null` 的分支只設定了 `Head`，沒有加上 `list.Count`，接完後 `Count` 仍是 0，迭代器什麼都走不到。
2. **`JackDictionary.GetValue` 只比對 hashCode**：`if (entry.hashCode == num)` 沒有像 `Add`、`SetValue` 一樣再比對 `key.Equals(key)`。兩個不同的 key 雜湊值相同（碰撞）時，會回傳先找到的那筆，也就是錯誤的值。補上 `&& entry.key.Equals(key)` 即可。
3. **`BFSIterator.Current` 改寫了 `Tree.Root`**：`Current` 的 getter 直接執行 `Tree.Root = _queue.Dequeue();`，走訪一次之後 `Root` 會停在最後一個被取出的節點，整棵樹就「不見了」，正好違反作業要求的「不可以汙染你的 Tree」。而且讀一次 `Current` 就出列一次，連續讀兩次會跳過節點。修正方向：用迭代器自己的欄位存目前節點，並把出列的動作移到 `MoveNext()`。
4. **`JackList.Insert` 的 index 超過長度時拋出 NullReferenceException**：方法上方的註解寫著「超過索引 => throw IndexoutOfRange」，但目前只檢查了 `index < 0`。當 `index > Count`（包含對空串列插入非 0 的位置）時，迴圈會走到 `node` 為 null 後再執行 `node.Next`，拋出的是 NullReferenceException。應在開頭加上 `index > Count` 的檢查。
