import { connect } from 'react-redux';
import { toggleLoading, setResults } from '../ComicResults/comicResultsActions';
import { deleteUserComic } from './DeleteUserComic/deleteUserComicAction';
import { getUserComics } from "./GetUserComics/getUserComicAction";
import { UserComics } from './UserComics';

const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

const mapDispatchToProps = dispatch => ({
  toggleLoading: isLoading => dispatch(toggleLoading(isLoading)),
  getUserComics: () => dispatch(getUserComics()),
  clearResults: () => dispatch(setResults([])),
  deleteUserComic: userComic => dispatch(deleteUserComic(userComic))
});

export const UserComicsContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(UserComics);
