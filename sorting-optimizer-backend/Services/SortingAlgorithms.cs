using System;
namespace SortingOptimizer.Services {
    public static class SortingAlgorithms {
        public static int[] BubbleSort(int[] arr) {
            var a = (int[])arr.Clone();
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (a[j] > a[j + 1]) {
                        (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    }
            return a;
        }

        public static int[] QuickSort(int[] arr) {
            var a = (int[])arr.Clone();
            QuickSortInternal(a, 0, a.Length - 1);
            return a;
        }
        private static void QuickSortInternal(int[] a, int lo, int hi) {
            if (lo >= hi) return;
            int pivot = a[(lo + hi) / 2];
            int i = lo, j = hi;
            while (i <= j) {
                while (a[i] < pivot) i++;
                while (a[j] > pivot) j--;
                if (i <= j) {
                    (a[i], a[j]) = (a[j], a[i]);
                    i++; j--;
                }
            }
            if (lo < j) QuickSortInternal(a, lo, j);
            if (i < hi) QuickSortInternal(a, i, hi);
        }

        public static int[] MergeSort(int[] arr) {
            var a = (int[])arr.Clone();
            a = MergeSortInternal(a);
            return a;
        }
        private static int[] MergeSortInternal(int[] a) {
            if (a.Length <= 1) return a;
            int mid = a.Length / 2;
            var left = MergeSortInternal(a[..mid]);
            var right = MergeSortInternal(a[mid..]);
            return Merge(left, right);
        }
        private static int[] Merge(int[] left, int[] right) {
            int i = 0, j = 0;
            var result = new int[left.Length + right.Length];
            int k = 0;
            while (i < left.Length && j < right.Length) {
                result[k++] = left[i] <= right[j] ? left[i++] : right[j++];
            }
            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];
            return result;
        }

        public static int[] InsertionSort(int[] arr) {
            var a = (int[])arr.Clone();
            int n = a.Length;
            for (int i = 1; i < n; i++) {
                int key = a[i];
                int j = i - 1;
                while (j >= 0 && a[j] > key) {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
            return a;
        }

        public static int[] SelectionSort(int[] arr) {
            var a = (int[])arr.Clone();
            int n = a.Length;
            for (int i = 0; i < n - 1; i++) {
                int minIdx = i;
                for (int j = i + 1; j < n; j++) {
                    if (a[j] < a[minIdx]) minIdx = j;
                }
                (a[i], a[minIdx]) = (a[minIdx], a[i]);
            }
            return a;
        }

        public static int[] HeapSort(int[] arr) {
            var a = (int[])arr.Clone();
            int n = a.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(a, n, i);
            for (int i = n - 1; i > 0; i--) {
                (a[0], a[i]) = (a[i], a[0]);
                Heapify(a, i, 0);
            }
            return a;
        }
        private static void Heapify(int[] a, int n, int i) {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && a[l] > a[largest]) largest = l;
            if (r < n && a[r] > a[largest]) largest = r;
            if (largest != i) {
                (a[i], a[largest]) = (a[largest], a[i]);
                Heapify(a, n, largest);
            }
        }
    }
}