import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import BookPage from '../pages/DashboardPage';
import axios from 'axios';
import axiosInstance  from '../axiosConfig';

jest.mock('axios');

describe('BookPage - Complex Scenario Testing', () => {
  it('fetches list of books, then fetches reviews for the first book', async () => {
    const books = [
      { id: 1, title: 'Book 1', author: { name: 'Author 1' }, reviews: [] },
      { id: 2, title: 'Book 2', author: { name: 'Author 2' }, reviews: [] }
    ];

    const reviews = [
      { id: 1, content: 'Great Book!', rating: 5 }
    ];

    axiosInstance.get.mockResolvedValueOnce({ data: { books, totalPages: 1 } });
    axiosInstance.get.mockResolvedValueOnce({ data: reviews });

    render(<BookPage />);

    await waitFor(() => screen.getByText('Books List'));

    expect(screen.getByText('Book 1')).toBeInTheDocument();

    fireEvent.click(screen.getByText('View Reviews'));

    await waitFor(() => screen.getByText('Great Book!'));

    expect(screen.getByText('Great Book!')).toBeInTheDocument();
  });

  it('displays message if no books found', async () => {
    const errorMessage = 'No books found.';
    axiosInstance.get.mockResolvedValueOnce({ data: { books: [], totalPages: 0 } });

    render(<BookPage />);

    await waitFor(() => screen.getByText('Books List'));

    expect(screen.getByText(errorMessage)).toBeInTheDocument();
  });

  it('displays loading message while data is being fetched', () => {
    const books = [
      { id: 1, title: 'Book 1', author: { name: 'Author 1' }, reviews: [] }
    ];
    axiosInstance.get.mockResolvedValueOnce({ data: { books, totalPages: 1 } });

    render(<BookPage />);

    expect(screen.getByText('Loading...')).toBeInTheDocument();
  });

  it('displays error message when API fails', async () => {
    const errorMessage = 'An error occurred while fetching the books. Please try again later.';
    axiosInstance.get.mockRejectedValueOnce(new Error('API Error'));

    render(<BookPage />);

    await waitFor(() => screen.getByText('Books List'));

    expect(screen.getByText(errorMessage)).toBeInTheDocument();
  });
});
