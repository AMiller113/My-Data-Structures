class Node:
    def __init__(self, right, left, value=None):
        self.value = value
        if type(right) != Node:
            self.right = None
        else:
            self.right = right
        if type(left) != Node:
            self.left = None
        else:
            self.left = left


class BinarySearchTree(object):
    def __init__(self, value=None):
        if value is None:
            self.root = Node(None, None, None)
            self.size = 0
        else:
            self.root = Node(None, None, value)
            self.size = 1

    def insert(self, root, value):
        if root.value > value and root.left is None:
            root.left = Node(None, None, value)
            self.size += 1
            return True
        elif root.value < value and root.right is None:
            root.right = Node(None, None, value)
            self.size += 1
            return True
        elif root.value > value and root.left is not None:
            self.insert(root.left, value)
        elif root.value < value and root.right is not None:
            self.insert(root.right, value)
        return False  # No duplicates

    def search(self, root, value):
        if root.value == value:
            return root
        elif root.value > value and root.left is not None:
            self.search(root.left, value)
        elif root.value < value and root.right is not None:
            self.search(root.right, value)

    def delete(self, root, value):
        if self.size == 0:
            return False
        if root.value == value:
            self.root = self.root.right
            self.size -= 1
            return True
        if root.right.value == value:
            root.right = root.right.right
            self.size -= 1
            return True
        elif root.left.value == value:
            root.left = root.left.right
            self.size -= 1
            return True
        elif root.value > value and root.left is not None:
            self.delete(root.left, value)
        elif root.value < value and root.right is not None:
            self.delete(root.right, value)
        return False

    def traverse(self, root):
        if root.left is not None:
            self.Traverse(root.left)
        print(root.value)
        if root.right is not None:
            self.Traverse(root.right)