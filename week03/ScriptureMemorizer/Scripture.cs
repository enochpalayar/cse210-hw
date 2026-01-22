using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide, Random rand)
    {
        int remaining = VisibleWordCount();
        if (remaining == 0 || numberToHide <= 0) return;

        int toHide = Math.Min(numberToHide, remaining);
        int hiddenCount = 0;

        while (hiddenCount < toHide)
        {
            int index = rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public int VisibleWordCount()
    {
        int count = 0;
        foreach (var w in _words)
        {
            if (!w.IsHidden()) count++;
        }
        return count;
    }

    public string GetDisplayText()
    {
        string display = "";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
