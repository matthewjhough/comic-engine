import { connect } from 'react-redux';
import { toggleLoading, setResults } from '../ComicResults/comicResultsActions';
import { getUserComics } from './userComicsActions';
import { UserComics } from './UserComics';

const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

const mapDispatchToProps = dispatch => ({
  toggleLoading: isLoading => dispatch(toggleLoading(isLoading)),
  getUserComics: () => dispatch(getUserComics()),
  clearResults: () => dispatch(setResults([]))
});

export const UserComicsContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(UserComics);
